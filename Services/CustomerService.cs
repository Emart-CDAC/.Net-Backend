using Emart_DotNet.Models;
using Emart_DotNet.Repositories;

namespace Emart_DotNet.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer?> GetCustomerByUserIdAsync(int userId)
        {
            return await _customerRepository.FindByUserIdAsync(userId);
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _customerRepository.FindByEmailAsync(email);
        }
    }
}
