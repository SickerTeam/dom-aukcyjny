using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Services
{
public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<string> RegisterUserAsync(UserRegistrationDTO dto)
    {
        //Line below has to be updated with the actual properties
        var user = new User { Email = dto.Email }; 
        var result = await _userManager.CreateAsync(user, dto.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Utilities.JwtUtils.GenerateJwtToken(user, "your-secret-key", "your-issuer", "your-audience", 60);
        }

        throw new Exception("Registration failed");
    }

      public async Task<string> LoginUserAsync(UserLoginDTO dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.KeepLoggedIn, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(dto.Email);
            return Utilities.JwtUtils.GenerateJwtToken(user, "your-secret-key", "your-issuer", "your-audience", 60);
        }

        throw new Exception("Login failed");
    }

    public async Task LogoutUserAsync(int id)
    {
        await _signInManager.SignOutAsync();
    }
}
}