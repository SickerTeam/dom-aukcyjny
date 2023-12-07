using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Utilities;
using Microsoft.AspNetCore.Identity;

namespace backend.Services
{
public class AuthenticationService : IAuthenticationService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly JwtUtils jwtUtils;

    public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _mapper = mapper;
        }

        public async Task<string> RegisterUserAsync(UserRegistrationDTO dto)
    {
        var user = _mapper.Map<User>(dto);
        var identityUser = _mapper.Map<IdentityUser>(user);
        identityUser.UserName = user.Email;

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);

            return jwtUtils.GenerateJwtToken(user);
        }

        throw new Exception($"Registration failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
    }

      public async Task<string> LoginUserAsync(UserLoginDTO dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.KeepLoggedIn, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
            return jwtUtils.GenerateJwtToken(user);
            }
        }

        throw new Exception("Login failed");
    }

    public async Task LogoutUserAsync(int id)
    {
        await _signInManager.SignOutAsync();
    }
}
}