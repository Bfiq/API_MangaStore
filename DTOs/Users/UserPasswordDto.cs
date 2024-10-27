using System.ComponentModel.DataAnnotations;

namespace API_Manga_ecommerce.DTOs.Users;

public class UserPasswordDto
{
    [Required]
    public required string Password { get; set; }
}
