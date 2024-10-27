using API_Manga_ecommerce.DTOs.Users;
using API_Manga_ecommerce.Models;

namespace API_Manga_ecommerce.Services.Users;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User?> GetUserById(int id);
    Task SaveUser(UserPostDto userPostDto);
    Task UpdateUser(UserPutDto userPutDto, int id);
    Task PartialUpdateUser(UserPatchDto userPatchDto, int id);
    Task UpdatePassword(UserPasswordDto userPasswordDto, int id);
    Task DeleteUser(int id);
    Task CheckIfUserExists(int id);
}
