using Emart_DotNet.Models;

namespace Emart_DotNet.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        
        Task<Product?> FindByIdAsync(int productId);
        
        Task<List<Product>> SearchProductsAsync(string keyword);
        
        Task<Product> SaveAsync(Product product);
        
        Task DeleteAsync(int productId);
        
        Task<bool> ExistsAsync(int productId);
    }
}