using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Repositories.Categories;

namespace API_Manga_ecommerce.Services.Categories;

public class CategoryService: ICategoryServices
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    //Get
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _categoryRepository.GetAllCategories();
    }

    //GetById
    public Task<Category?> GetCategoryById(int id)
    {
        return _categoryRepository.GetCategoryById(id);
    }

    //Post
    public Task<Category> SaveCategory(Category category)
    {
        return _categoryRepository.AddCategory(category);
    }

    //Put
    public Task<Category?> UpdateCategory(Category category, int id)
    {
        return _categoryRepository.UpdateCategory(category, id);
    }

    //Delete
    public Task DeleteCategory(int id)
    {
        return _categoryRepository.DeleteCategory(id);
    }


}
