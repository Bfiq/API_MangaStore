using API_Manga_ecommerce.DTOs;
using API_Manga_ecommerce.DTOs.Categories;
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
    public async Task<Category?> UpdateCategory(CategoryPutDto categoryPutDto, int id)
    {
        var currentCategory = await _categoryRepository.GetCategoryById(id);

        currentCategory!.Name = categoryPutDto.Name;
        currentCategory!.Description = categoryPutDto.Description;

        return await _categoryRepository.UpdateCategory(currentCategory, id);
    }

    //Patch
    public async Task<Category?> PartialUpdateCategory(CategoryPatchDto categoryPatchDto, int id)
    {
        var currentCategory = await _categoryRepository.GetCategoryById(id);

        if (!string.IsNullOrWhiteSpace(categoryPatchDto.Name))
        {
            currentCategory!.Name = categoryPatchDto.Name;
        }

        if (!string.IsNullOrWhiteSpace(categoryPatchDto.Description))
        {
            currentCategory!.Description = categoryPatchDto.Description;
        }

        return await _categoryRepository.UpdateCategory(currentCategory!, id);
    }

    //Delete
    public Task DeleteCategory(int id)
    {
        return _categoryRepository.DeleteCategory(id);
    }

    public async Task CheckIfCategoryExists(int id)
    {
        _ = await _categoryRepository.GetCategoryById(id) ?? throw new KeyNotFoundException($"No se encontro el id {id}");
    }
}
