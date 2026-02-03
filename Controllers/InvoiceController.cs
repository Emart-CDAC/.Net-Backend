using Emart_DotNet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Emart_DotNet.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("download/{orderId}")]
        public async Task<IActionResult> DownloadInvoice(int orderId)
        {
            try
            {
                byte[] pdfBytes = await _invoiceService.GenerateInvoicePdfAsync(orderId);
                return File(pdfBytes, "application/pdf", $"Invoice_{orderId}.pdf");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpPost("generate/{orderId}")]
        public async Task<IActionResult> GenerateInvoice(int orderId)
        {
             try
            {
                var invoice = await _invoiceService.CreateInvoiceForOrderAsync(orderId);
                return Ok(invoice);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
