using API_Manga_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Manga_ecommerce.Repositories.Auth;

public class AuthRepository:IAuthRepository
{
    private DatabaseContext _dbContext;

    public AuthRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    //login
    public async Task<User?> Login(string email)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(t => t.Email == email);
    }
}
