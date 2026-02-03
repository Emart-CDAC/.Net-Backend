using Emart_DotNet.Models;

namespace Emart_DotNet.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        
        Task<Product?> GetProductByIdAsync(int id);
        
        Task<Product> CreateProductAsync(Product product);
        
        Task<Product> UpdateProductAsync(int id, Product product);
        
        Task DeleteProductAsync(int id);
        
        Task<List<Product>> SearchProductsAsync(string keyword);
    }
}