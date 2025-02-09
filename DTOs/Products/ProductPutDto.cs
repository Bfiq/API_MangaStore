using System.ComponentModel.DataAnnotations;

namespace API_Manga_ecommerce.DTOs.Products;

public class ProductPutDto
{
    [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }
    public required bool isDigital { get; set; }
    public required string Url { get; set; }
    public required int CategoryId { get; set; }
}

