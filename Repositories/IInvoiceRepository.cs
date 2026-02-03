using Emart_DotNet.Models;

namespace Emart_DotNet.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task<Invoice?> GetInvoiceByIdAsync(int invoiceId);
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
        Task<bool> DeleteInvoiceAsync(int invoiceId);
    }
}
