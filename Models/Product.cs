namespace API_Manga_ecommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Product
{
    public int ProductId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public required int Quantity { get; set; }
    public required bool IsDigital { get; set; }
    public string? Url { get; set; }
    public required int CategoryId { get; set; }
    public virtual Category? Category{ get; set; }
    [JsonIgnore]
    public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
}
