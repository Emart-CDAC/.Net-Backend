using Emart_DotNet.Models;
using System.Threading.Tasks;

namespace Emart_DotNet.Services
{
    public interface IPaymentService
    {
        Payment ProcessPayment(Payment payment);
        PaymentStatus GetPaymentStatus(int orderId);
        PaymentMethod GetPaymentMethod(int orderId);
        
        // Razorpay
        string CreateRazorpayOrder(int orderId); // Returns Razorpay Order ID string
        string CreateRazorpayOrder(double amount);
        Payment VerifyRazorpayPayment(int orderId, Payment paymentDetails); 
        
        // COD
        Payment CreateCashOnDeliveryPayment(int orderId);
    }
}