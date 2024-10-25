using API_Manga_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Manga_ecommerce.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DatabaseContext _dbContext;

    public CategoryRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    //Get
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        try
        {            
            return await _dbContext.Categories.ToListAsync();
        }
        catch(Exception ex)
        {
            throw new Exception("Error al obtener los datos");
        }
    }

    //Get<id>
    public async Task<Category?> GetCategoryById(int categoryId)
    {
        return await _dbContext.Categories.FindAsync(categoryId);
    }

    //Post
    public async Task<Category> AddCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    //Update
    public async Task<Category?> UpdateCategory(Category category, int categoryId)
    {
        var currentCategory = await _dbContext.Categories.FindAsync(categoryId);

        if (currentCategory != null)
        {
            currentCategory.Name = category.Name;
            currentCategory.Description = category.Description;
            await _dbContext.SaveChangesAsync();
        }
        return currentCategory;
    }

    //Delete
    public async Task DeleteCategory(int categoryId)
    {
        var currentCategory = await _dbContext.Categories.FindAsync(categoryId);

        _dbContext.Categories.Remove(currentCategory!);
        await _dbContext.SaveChangesAsync();
    }
}
