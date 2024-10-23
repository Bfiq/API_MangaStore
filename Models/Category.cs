using System.Text.Json.Serialization;

namespace API_Manga_ecommerce.Models;

public class Category
{
    public int CategoryId {get; set;}
    public required string Name { get; set;}
    public string? Description { get; set;}
    [JsonIgnore]
    public ICollection<Product> Products { get; set;}
}