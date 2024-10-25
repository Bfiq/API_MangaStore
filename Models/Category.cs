using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Manga_ecommerce.Models;

public class Category
{
    public int CategoryId {get; set;}
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    public required string Name { get; set;}
    public string? Description { get; set;}
    [JsonIgnore]
    public virtual ICollection<Product>? Products { get; set;}
}