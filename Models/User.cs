using System.Text.Json.Serialization;

namespace API_Manga_ecommerce.Models;

public class User
{
    public int UserId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required Role Role { get; set; }
    public string? shippingAddress { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; }
}

public enum Role
{
    Administrator,
    Customer
}
