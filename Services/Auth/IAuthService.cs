using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Services.Auth;

public interface IAuthService
{
    Task<string> Login(LoginRq loginRq);
}
