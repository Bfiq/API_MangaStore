using API_Manga_ecommerce.Exceptions;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API_Manga_ecommerce.Controllers;

[Route("api/[Controller]")]
public class AuthController:ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRq loginRq)
    {
        try
        {
            var token = await _authService.Login(loginRq);
            return Ok(new { Token = token });
        }
        catch(EmailDoesNotExistException ex)
        {
            return NotFound(ex.Message);
        }
        catch(IncorrectPasswordException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("-------------ERROR--------------");
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Error");
        }
    }
}
