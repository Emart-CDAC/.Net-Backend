using Emart_DotNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Emart_DotNet.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> SaveAsync(Order order)
        {
            if (order.OrderId == 0)
                _context.Orders.Add(order);
            else
                _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> FindByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Invoices) // Changed from CustomerInvoices (check model)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .Include(o => o.Address)
                .Include(o => o.Store)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<List<Order>> FindByCustomerUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }

    // OrderItem Repository
    public interface IOrderItemRepository
    {
        Task<OrderItem> SaveAsync(OrderItem orderItem);
    }

    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _context;
        public OrderItemRepository(AppDbContext context) { _context = context; }

        public async Task<OrderItem> SaveAsync(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem); 
            await _context.SaveChangesAsync();
            return orderItem;
        }
    }


    // Store Repository
    public interface IStoreRepository
    {
        Task<Store?> FindByIdAsync(int storeId);
    }
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;
        public StoreRepository(AppDbContext context) { _context = context; }
        public async Task<Store?> FindByIdAsync(int storeId)
        {
            return await _context.Stores.FindAsync(storeId);
        }
    }

    // Payment Repository
    public interface IPaymentRepository
    {
        Task<Payment> SaveAsync(Payment payment);
        Task<Payment?> FindByOrderOrderIdAsync(int orderId);
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context) { _context = context; }

        public async Task<Payment> SaveAsync(Payment payment)
        {
            if (payment.PaymentId == 0)
                _context.Payments.Add(payment);
            else
                _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment?> FindByOrderOrderIdAsync(int orderId)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(p => p.OrderId == orderId);
        }
    }
    
    // Address Repository
    public interface IAddressRepository
    {
        Task<Address?> FindByIdAsync(int addressId);
    }
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext context) { _context = context; }
        public async Task<Address?> FindByIdAsync(int addressId)
        {
            return await _context.Addresses.FindAsync(addressId);
        }
    }



}
