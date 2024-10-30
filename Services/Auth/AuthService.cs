using API_Manga_ecommerce.Exceptions;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Repositories.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Manga_ecommerce.Services.Auth;

public class AuthService:IAuthService
{
    private IAuthRepository _authRepository;
    private IConfiguration _configuration;

    public AuthService(IAuthRepository authRepository, IConfiguration configuration)
    {
        _authRepository = authRepository;
        _configuration = configuration;
    }

    //login
    public async Task<string> Login(LoginRq loginRq)
    {
        var user = await _authRepository.Login(loginRq.Email);

        if (user == null)
        {
            throw new EmailDoesNotExistException("Correo Incorrecto");
        }

        if (!VerifyPassword(loginRq.Password, user.Password))
        {
            throw new IncorrectPasswordException("Contraseña Incorrecta");
        }

        return GenerateToken(user);
    }

    private bool VerifyPassword(string password, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }

    private string GenerateToken(User user)
    {
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpiryMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
