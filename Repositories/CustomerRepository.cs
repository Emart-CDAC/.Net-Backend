using Emart_DotNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Emart_DotNet.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> FindByIdAsync(int userId);
        Task<Customer> SaveAsync(Customer customer);
        Task<Customer?> FindByEmailAsync(string email);
        Task<bool> ExistsAsync(int userId);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> FindByIdAsync(int userId)
        {
            return await _context.Customers.FindAsync(userId);
        }

        public async Task<Customer> SaveAsync(Customer customer)
        {
            if (customer.UserId == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                _context.Customers.Update(customer);
            }
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> FindByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }
        
        public async Task<bool> ExistsAsync(int userId)
        {
             return await _context.Customers.AnyAsync(c => c.UserId == userId);
        }
    }
}
