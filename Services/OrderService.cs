using Emart_DotNet.DTOs;
using Emart_DotNet.Models;
using Emart_DotNet.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_DotNet.Services
{

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly ICartRepository _cartRepo;
        private readonly ICartItemRepository _cartItemRepo;
        private readonly IOrderItemRepository _orderItemRepo;
        private readonly IAddressRepository _addressRepo;
        private readonly IStoreRepository _storeRepo;


        public OrderService(
            IOrderRepository orderRepo,
            ICustomerRepository customerRepo,
            ICartRepository cartRepo,
            ICartItemRepository cartItemRepo,
            IOrderItemRepository orderItemRepo,
            IAddressRepository addressRepo,
            IStoreRepository storeRepo)
        {
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
            _cartRepo = cartRepo;
            _cartItemRepo = cartItemRepo;
            _orderItemRepo = orderItemRepo;
            _addressRepo = addressRepo;
            _storeRepo = storeRepo;
        }

        public async Task<Order> PlaceOrderAsync(PlaceOrderRequestDTO req)
        {
            var customer = await _customerRepo.FindByIdAsync(req.UserId)
                           ?? throw new Exception("Customer not found");

            var cart = await _cartRepo.FindByCustomerAsync(customer)
                       ?? throw new Exception("Cart not found");
            
            var cartItems = await _cartItemRepo.FindByCartAsync(cart.CartId);
            if (!cartItems.Any())
            {
                throw new Exception("Cart is empty");
            }
            
            // Validate e-Points sufficiency again just in case
            if ((cart.UsedEpoints ?? 0) > (customer.Epoints ?? 0))
            {
                throw new Exception("Insufficient e-points");
            }
            
            Order order = new Order
            {
                UserId = customer.UserId,
                CartId = cart.CartId,
                OrderDate = DateTime.Now,
                EpointsUsed = cart.UsedEpoints,
                EpointsEarned = cart.EarnedEpoints,
                TotalAmount = cart.FinalPayableAmount
            };

            // Status Enum Mapping
            if (Enum.TryParse<OrderStatus>("Confirmed", true, out var statusEnum))
            {
                 order.Status = statusEnum; // Default to Confirmed as per Java
            }
            else
            {
                 order.Status = OrderStatus.Confirmed; 
            }

            // Delivery Type Mapping
            if (Enum.TryParse<DeliveryType>(req.DeliveryType, true, out var deliveryTypeEnum))
            {
                 order.DeliveryType = deliveryTypeEnum;
            }

            // Payment Method Mapping
            if (Enum.TryParse<PaymentMethod>(req.PaymentMethod, true, out var pmEnum))
            {
                order.PaymentMethod = pmEnum;
            }

            // Address or Store
            if (order.DeliveryType == DeliveryType.HomeDelivery)
            {
                var address = await _addressRepo.FindByIdAsync(req.AddressId ?? 0)
                              ?? throw new Exception("Address not found");
                order.AddressId = address.AddressId;
            }
            else
            {
                var store = await _storeRepo.FindByIdAsync(req.StoreId ?? 0)
                             ?? throw new Exception("Store not found");
                order.StoreId = store.StoreId;
            }

            // Payment Status
            order.PaymentStatus = (order.PaymentMethod == PaymentMethod.Cash) 
                                  ? PaymentStatus.Pending 
                                  : PaymentStatus.Paid;

            // Save Order
            order = await _orderRepo.SaveAsync(order);

            // Create Order Items
            foreach (var ci in cartItems)
            {
                OrderItem oi = new OrderItem
                {
                    OrderId = order.OrderId,
                    ProductId = ci.ProductId ?? 0,
                    Quantity = ci.Quantity ?? 0,
                    Price = ci.Product?.NormalPrice,
                    Subtotal = ci.Subtotal
                };
                await _orderItemRepo.SaveAsync(oi);
            }

            // Update E-Points
            customer.Epoints = (customer.Epoints ?? 0) - (cart.UsedEpoints ?? 0) + (cart.EarnedEpoints ?? 0);
            await _customerRepo.SaveAsync(customer);
            
            // Generate Invoice (Placeholder for Service call)
            // await _invoiceService.AddInvoiceAsync(order.OrderId);

            // Generate COD Payment (Placeholder)
            // if (order.PaymentMethod == PaymentMethod.Cash) ...

            // Clear Cart
            await _cartItemRepo.DeleteByCartIdAsync(cart.CartId);
            cart.TotalMrp = 0;
            cart.FinalPayableAmount = 0;
            cart.UsedEpoints = 0;
            cart.EpointDiscount = 0;
            cart.EarnedEpoints = 0;
            await _cartRepo.SaveAsync(cart);

             // Send Email (Placeholder)

             return order;
        }

        public async Task<Order> UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _orderRepo.FindByIdAsync(orderId)
                        ?? throw new Exception("Order not found");
            
            if (Enum.TryParse<OrderStatus>(status, true, out var st))
            {
                order.Status = st;
            }
            return await _orderRepo.SaveAsync(order);
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _orderRepo.FindByCustomerUserIdAsync(userId);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepo.FindByIdAsync(orderId)
                   ?? throw new Exception("Order not found");
        }
    }
}
