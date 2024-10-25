using System.ComponentModel.DataAnnotations;

namespace API_Manga_ecommerce.DTOs.Categories;

public class CategoryPutDto
{
    [Required]
    [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
}
