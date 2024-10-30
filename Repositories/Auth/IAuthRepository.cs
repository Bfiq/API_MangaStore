using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Repositories.Auth;

public interface IAuthRepository
{
    Task<User?> Login(string email);
}
