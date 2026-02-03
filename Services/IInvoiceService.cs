using Emart_DotNet.Models;

namespace Emart_DotNet.Services
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task<Invoice?> GetInvoiceByIdAsync(int invoiceId);
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<bool> DeleteInvoiceAsync(int invoiceId);
    }
}
