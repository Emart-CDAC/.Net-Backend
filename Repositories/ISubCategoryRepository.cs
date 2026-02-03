using Emart_DotNet.Models;

namespace Emart_DotNet.Repositories
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryIdAsync(int categoryId);
    }
}
