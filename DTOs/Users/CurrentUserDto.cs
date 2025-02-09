using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.DTOs.Users;

public class CurrentUserDto
{
    public int UserId { get; set; }
    public Role Role { get; set; }
}
