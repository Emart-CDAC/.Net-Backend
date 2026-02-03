using Emart_DotNet.Models;

namespace Emart_DotNet.Services
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryIdAsync(int categoryId);
    }
}
