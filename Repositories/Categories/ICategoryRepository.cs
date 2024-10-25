using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Repositories.Categories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category?> GetCategoryById(int categoryId);
    Task<Category> AddCategory(Category category);
    Task<Category?> UpdateCategory(Category category, int categoryId);
    Task DeleteCategory(int categoryId);
}
