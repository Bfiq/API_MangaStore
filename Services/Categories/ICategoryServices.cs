using API_Manga_ecommerce.DTOs;
using API_Manga_ecommerce.DTOs.Categories;
using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Services.Categories
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(int id);
        Task<Category> SaveCategory(Category category);
        Task<Category?> UpdateCategory(CategoryPutDto categoryPutDto, int id);
        Task<Category?> PartialUpdateCategory(CategoryPatchDto categoryPatchDto, int id);
        Task DeleteCategory(int id);
        Task CheckIfCategoryExists(int id);
    }
}
