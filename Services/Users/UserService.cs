using API_Manga_ecommerce.DTOs.Users;
using API_Manga_ecommerce.Exceptions;
using API_Manga_ecommerce.Models;
using API_Manga_ecommerce.Repositories.Users;
using BCrypt.Net;
using System.ComponentModel.DataAnnotations;

namespace API_Manga_ecommerce.Services.Users;

public class UserService:IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //Get All
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    //Get Id
    public async Task<User?> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    //Post
    public async Task SaveUser(UserPostDto userPostDto)
    {
        if (!new EmailAddressAttribute().IsValid(userPostDto.Email)) throw new InvalidEmailFormatException("El formato del correo electrónico no es válido.");
        if (await _userRepository.ValidateEmail(userPostDto.Email)) throw new EmailAlreadyExistsException("El correo electrónico ya está en uso.");

        userPostDto.Password = BCrypt.Net.BCrypt.HashPassword(userPostDto.Password);
        var user = new User
        {
            Name = userPostDto.Name,
            Email = userPostDto.Email,
            Password = userPostDto.Password,
            Role = userPostDto.Role
        };
        if (!string.IsNullOrWhiteSpace(userPostDto.shippingAddress)) user.shippingAddress = userPostDto.shippingAddress;
        await _userRepository.SaveUser(user);
    }

    //Put
    public async Task UpdateUser(UserPutDto userPutDto, int id)
    {
        var currentUser = await _userRepository.GetUserById(id);

        if (!new EmailAddressAttribute().IsValid(userPutDto.Email)) throw new InvalidEmailFormatException("El formato del correo electrónico no es válido.");

        Console.WriteLine(currentUser!.Email);
        Console.WriteLine(userPutDto!.Email);
        if (currentUser!.Email != userPutDto.Email)
        {
            if (await _userRepository.ValidateEmail(userPutDto.Email)) throw new EmailAlreadyExistsException("El correo electrónico ya está en uso.");
        }

        currentUser!.Name = userPutDto.Name;
        currentUser!.Email = userPutDto.Email;
        currentUser!.Role = userPutDto.Role;
        currentUser!.shippingAddress = userPutDto.shippingAddress;

        await _userRepository.UpdateUser(currentUser, id);
    }

    //Patch
    public async Task PartialUpdateUser(UserPatchDto userPatchDto, int id)
    {
        var currentUser = await _userRepository.GetUserById(id);

        if (!string.IsNullOrWhiteSpace(userPatchDto.Name)) currentUser!.Name = userPatchDto.Name;
        if ((!string.IsNullOrWhiteSpace(userPatchDto.Email)) && (currentUser!.Email != userPatchDto.Email))
        {
            if (!new EmailAddressAttribute().IsValid(userPatchDto.Email)) throw new InvalidEmailFormatException("El formato del correo electrónico no es válido.");
            if (await _userRepository.ValidateEmail(userPatchDto.Email)) throw new EmailAlreadyExistsException("El correo electrónico ya está en uso.");
            currentUser!.Email = userPatchDto.Email;
        }
        if (userPatchDto.Role.HasValue) currentUser!.Role = (Role)userPatchDto.Role;
        if (!string.IsNullOrWhiteSpace(userPatchDto.shippingAddress)) currentUser!.shippingAddress = userPatchDto.shippingAddress;

        await _userRepository.UpdateUser(currentUser!, id);
    }

    //Patch Password
    public async Task UpdatePassword(UserPasswordDto userPasswordDto, int id)
    {
        var currentUser = await _userRepository.GetUserById(id);



        if (!string.IsNullOrWhiteSpace(userPasswordDto.Password))
        {
            userPasswordDto.Password = BCrypt.Net.BCrypt.HashPassword(userPasswordDto.Password);
            currentUser!.Password = userPasswordDto.Password;
        }

        await _userRepository.UpdateUser(currentUser!, id);
    }

    //Delete
    public async Task DeleteUser(int id)
    {
        await _userRepository.DeleteUser(id);
    }

    //CheckId
    public async Task CheckIfUserExists(int id)
    {
        _ = await _userRepository.GetUserById(id) ?? throw new KeyNotFoundException($"No se encontro el usuario con el id {id}");
    }
}
