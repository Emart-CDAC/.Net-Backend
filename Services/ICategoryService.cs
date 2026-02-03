using Emart_DotNet.Models;

namespace Emart_DotNet.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> GetParentCategoriesAsync();
        Task<IEnumerable<Category>> GetChildCategoriesAsync(int parentId);
        Task<Category?> GetCategoryByIdAsync(int id);
    }
}
