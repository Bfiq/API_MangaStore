using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Repositories.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task SaveProduct(Product product);
        Task UpdateProduct(Product product, int id);
        Task DeleteProduct(int id);
    }
}
