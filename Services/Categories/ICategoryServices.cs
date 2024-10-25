using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Services.Categories
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(int id);
        Task<Category> SaveCategory(Category category);
        Task<Category?> UpdateCategory(Category category, int id);
        Task DeleteCategory(int id);
    }
}
