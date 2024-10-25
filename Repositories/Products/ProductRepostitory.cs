using API_Manga_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Manga_ecommerce.Repositories.Products;

public class ProductRepostitory: IProductRepository
{
    private readonly DatabaseContext _dbContext;

    public ProductRepostitory(DatabaseContext database)
    {
        _dbContext = database;
    }

    //Get All
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _dbContext.Products.Include(p => p.Category).ToListAsync();
    }

    //Get Id
    public async Task<Product?> GetProductById(int id)
    {
        return await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
    }

    //Post
    public async Task SaveProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    //Put
    public async Task UpdateProduct(Product product, int id)
    {
        var currentProduct = await _dbContext.Products.FindAsync(id);

        if (currentProduct != null)
        {
            currentProduct = product;
            await _dbContext.SaveChangesAsync();
        }
    }

    //Delete
    public  async Task DeleteProduct(int id)
    {
        var currentProduct = await _dbContext.Products.FindAsync(id);
        _dbContext.Products.Remove(currentProduct!);
        await _dbContext.SaveChangesAsync();
    }

}
