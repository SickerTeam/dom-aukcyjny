using AutoMapper;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Services
{
public class AuthenticationService : IAuthenticationService
{
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public AuthenticationService( SignInManager<User> signInManager, IMapper mapper, IUserService userService)
    {
        _signInManager = signInManager;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<string> RegisterUserAsync(UserRegistrationDTO dto)
    {
        //Line below has to be updated with the actual properties
        var user = _mapper.Map<User>(dto); 
        var result = await _userService.AddUserAsync(dto);

        if (true)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
           // return Utilities.JwtUtils.GenerateJwtToken(user, "your-secret-key", "your-issuer", "your-audience", 60);
        }

        throw new Exception("Registration failed");
    }

      public async Task<string> LoginUserAsync(UserLoginDTO dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.KeepLoggedIn, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var user = await _userService.GetUserByIdAsync(1);
            //return Utilities.JwtUtils.GenerateJwtToken(user, "your-secret-key", "your-issuer", "your-audience", 60);
        }

        throw new Exception("Login failed");
    }

    public async Task LogoutUserAsync(int id)
    {
        await _signInManager.SignOutAsync();
    }
}
}