using backend.DTOs;
using backend.Data.Models;
using backend.Utilities;

namespace backend.Services
{
    public class AuthenticationService(IUserService userService, JwtUtils jwtUtils) : IAuthenticationService
    {
        private readonly IUserService _userService = userService;
        private readonly JwtUtils _jwtUtils = jwtUtils;

        public async Task<string> RegisterUserAsync(UserCreationDTO registrationDto)
        {
            ArgumentNullException.ThrowIfNull(registrationDto);

            registrationDto.Password = PasswordUtils.HashPassword(registrationDto.Password);
            await _userService.AddUserAsync(registrationDto);

            DbUser user = await _userService.GetUserByEmailAsync(registrationDto.Email) ?? throw new Exception("User not found");
            var token = _jwtUtils.GenerateJwtToken(user);

            return token;
        }

        public async Task<string> LoginUserAsync(UserLoginDTO loginDto)
        {
            ArgumentNullException.ThrowIfNull(loginDto);

            DbUser user = await _userService.GetUserByEmailAsync(loginDto.Email) ?? throw new Exception("User not found.");
            if (!PasswordUtils.VerifyPassword(user.Password, loginDto.Password))
            {
                throw new Exception("Invalid password.");
            }

            if (user.Password == null)
            {
                throw new Exception("User password is null.");
            }

            var token = _jwtUtils.GenerateJwtToken(user);

            return token;
        }
    }
}