using API_Manga_ecommerce.DTOs.Products;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Repositories.Products;

namespace API_Manga_ecommerce.Services.Products
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }

        //Get All
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        //Get Id
        public async Task<Product?> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        //Post
        public async Task SaveProduct(Product product)
        {
            await _productRepository.SaveProduct(product);
        }

        //Put
        public async Task UpdateProduct(ProductPutDto productPutDto, int id)
        {
            var currentProduct = await _productRepository.GetProductById(id);

            currentProduct!.Name = productPutDto.Name;
            currentProduct!.Description = productPutDto.Description;
            currentProduct!.Price = productPutDto.Price;
            currentProduct!.Quantity = productPutDto.Quantity;
            currentProduct!.Url = productPutDto.Url;
            currentProduct!.CategoryId = productPutDto.CategoryId;
            currentProduct!.IsDigital = productPutDto.isDigital;

            await _productRepository.UpdateProduct(currentProduct, id);
        }

        //Patch
        public async Task PartialUpdateProduct(ProductPatchDto productPatchDto, int id)
        {
            var currentProduct = await _productRepository.GetProductById(id);

            if (!string.IsNullOrWhiteSpace(productPatchDto.Name)) currentProduct!.Name = productPatchDto.Name;
            if (!string.IsNullOrWhiteSpace(productPatchDto.Description)) currentProduct!.Description = productPatchDto.Description;
            if (productPatchDto.Price.HasValue) currentProduct!.Price = productPatchDto.Price;
            if (productPatchDto.Quantity.HasValue) currentProduct!.Quantity = productPatchDto.Quantity.Value;
            if (!string.IsNullOrWhiteSpace(productPatchDto.Url)) currentProduct!.Url = productPatchDto.Url;
            if (productPatchDto.CategoryId.HasValue) currentProduct!.CategoryId = productPatchDto.CategoryId.Value;

            await _productRepository.UpdateProduct(currentProduct!, id);
        }

        //Delete
        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        //CheckId
        public async Task CheckIfCategoryExists(int id)
        {
            _ = await _productRepository.GetProductById(id) ?? throw new KeyNotFoundException($"No se encontro el producto con el id {id}");
        }
    }
}
