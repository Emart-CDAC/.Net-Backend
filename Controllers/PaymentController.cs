using Emart_DotNet.Models;
using Emart_DotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emart_DotNet.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create-order/{orderId}")]
        public IActionResult CreateRazorpayOrder(int orderId)
        {
            try
            {
                string response = _paymentService.CreateRazorpayOrder(orderId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("verify-razorpay-payment/{orderId}")]
        public IActionResult VerifyRazorpayPayment(int orderId, [FromBody] Payment paymentDetails)
        {
            try
            {
                var payment = _paymentService.VerifyRazorpayPayment(orderId, paymentDetails);
                 if (payment.Status == PaymentStatus.Paid)
                {
                    return Ok(payment);
                }
                return BadRequest(new { message = "Payment Verification Failed", payment });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
