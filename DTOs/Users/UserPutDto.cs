using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.DTOs.Users;

public class UserPutDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required Role Role { get; set; }
    public string? shippingAddress { get; set; }
}
