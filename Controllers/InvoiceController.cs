using Emart_DotNet.Models;
using Emart_DotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emart_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdInvoice = await _service.CreateInvoiceAsync(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = createdInvoice.InvoiceId }, createdInvoice);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(int id)
        {
            var invoice = await _service.GetInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllInvoices()
        {
            var invoices = await _service.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _service.DeleteInvoiceAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
