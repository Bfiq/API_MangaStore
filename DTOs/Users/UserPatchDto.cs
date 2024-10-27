using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.DTOs.Users;

public class UserPatchDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public Role? Role { get; set; }
    public string? shippingAddress { get; set; }
}
