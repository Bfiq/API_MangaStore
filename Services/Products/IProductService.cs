using API_Manga_ecommerce.DTOs.Products;
using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Services.Products;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product?> GetProductById(int id);
    Task SaveProduct(Product product);
    Task UpdateProduct(ProductPutDto productPutDto, int id);
    Task PartialUpdateProduct(ProductPatchDto productPatchDto, int id);
    Task DeleteProduct(int id);
    Task CheckIfCategoryExists(int id);
}
