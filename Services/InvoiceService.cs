using Emart_DotNet.Models;
using Emart_DotNet.Repositories;

namespace Emart_DotNet.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceService(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            return await _repository.CreateInvoiceAsync(invoice);
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int invoiceId)
        {
            return await _repository.GetInvoiceByIdAsync(invoiceId);
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _repository.GetAllInvoicesAsync();
        }

        public async Task<bool> DeleteInvoiceAsync(int invoiceId)
        {
            return await _repository.DeleteInvoiceAsync(invoiceId);
        }
    }
}
