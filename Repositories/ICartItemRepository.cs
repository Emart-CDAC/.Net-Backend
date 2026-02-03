using Emart_DotNet.Models;

namespace Emart_DotNet.Repositories
{
    public interface ICartItemRepository
    {
        Task<CartItem?> FindByCartAndProductAsync(int cartId, int productId);
        
        Task<List<CartItem>> FindByCartAsync(int cartId);
        
        Task<CartItem> SaveAsync(CartItem cartItem);
        
        Task DeleteAsync(CartItem cartItem);
        
        Task DeleteByCartIdAsync(int cartId);
        
        Task<CartItem?> FindByIdAsync(int cartItemId);
    }
}