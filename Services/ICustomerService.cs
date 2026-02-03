using Emart_DotNet.Models;

namespace Emart_DotNet.Services
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerByUserIdAsync(int userId);
        
        Task<Customer?> GetCustomerByEmailAsync(string email);
    }
}
