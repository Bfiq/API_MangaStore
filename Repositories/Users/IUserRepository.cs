using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Repositories.Users;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User?> GetUserById(int id);
    Task SaveUser(User user);
    Task UpdateUser(User user, int id);
    Task DeleteUser(int id);
    Task<bool> ValidateEmail(string email);
}
