using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.DTOs.Users;

public class UserPostDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required Role Role { get; set; }
    public string? shippingAddress { get; set; }
}
