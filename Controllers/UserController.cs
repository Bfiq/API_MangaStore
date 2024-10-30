using API_Manga_ecommerce.DTOs.Products;
using API_Manga_ecommerce.DTOs.Users;
using API_Manga_ecommerce.Exceptions;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Manga_ecommerce.Controllers;

[Route("api/[controller]")]
public class UserController:ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService) {  _userService = userService; }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _userService.GetAllUsers());
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            await _userService.CheckIfUserExists(id);
            return Ok(await _userService.GetUserById(id));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserPostDto userPostDto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.SaveUser(userPostDto);
            return Created();
        }
        catch (InvalidEmailFormatException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (EmailAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Put([FromBody] UserPutDto userPutDto, int id)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.CheckIfUserExists(id);
            await _userService.UpdateUser(userPutDto, id);
            return Ok("Usuario Actualizado");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidEmailFormatException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (EmailAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPatch("{id}")]
    [Authorize]
    public async Task<IActionResult> Patch([FromBody] UserPatchDto userPatchDto, int id)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.CheckIfUserExists(id);
            await _userService.PartialUpdateUser(userPatchDto, id);
            return Ok("Usuario Actualizado");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidEmailFormatException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (EmailAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }

    [HttpPatch("{id}/password")]
    [Authorize]
    public async Task<IActionResult> PatchPassword([FromBody] UserPasswordDto userPasswordDto, int id)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.CheckIfUserExists(id);
            await _userService.UpdatePassword(userPasswordDto, id);
            return Ok("Contraseña Actualizada");
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return BadRequest("Error");
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _userService.CheckIfUserExists(id);
            await _userService.DeleteUser(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error");
        }
    }
}
