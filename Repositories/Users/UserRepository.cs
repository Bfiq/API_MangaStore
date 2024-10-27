using API_Manga_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Manga_ecommerce.Repositories.Users;

public class UserRepository: IUserRepository
{
    private DatabaseContext _dbContext;

    public UserRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    //Get All
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    //Get Id
    public async Task<User?> GetUserById(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    //Post
    public async Task SaveUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    //Put
    public async Task UpdateUser(User user, int id)
    {
        var currentUser = await _dbContext.Users.FindAsync(id);

        if (currentUser != null)
        {
            currentUser = user;
            await _dbContext.SaveChangesAsync();
        }
    }

    //Delete
    public async Task DeleteUser(int id)
    {
        var currentUser = await _dbContext.Users.FindAsync(id);
        _dbContext.Users.Remove(currentUser!);
        await _dbContext.SaveChangesAsync();
    }

    //Validate Email
    public async Task<bool> ValidateEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(t=> t.Email == email);
    }
}
