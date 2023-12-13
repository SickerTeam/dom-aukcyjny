using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Utilities;

namespace backend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;

        private readonly IUserService _userService;
        private readonly JwtUtils _jwtUtils;

        public AuthenticationService(IMapper mapper, IUserService userService, JwtUtils jwtUtils)
        {
            _mapper = mapper;
            _userService = userService;
            _jwtUtils = jwtUtils;
        }

        public async Task<string> RegisterUserAsync(UserCreationDTO registrationDto)
        {
            if (registrationDto == null)
            {
                throw new ArgumentNullException(nameof(registrationDto));
            }

            registrationDto.Password = PasswordUtils.HashPassword(registrationDto.Password);
            User user = _mapper.Map<User>(registrationDto);
            await _userService.AddUserAsync(registrationDto);

            var token = _jwtUtils.GenerateJwtToken(user);

            return token;
        }

        public async Task<string> LoginUserAsync(UserLoginDTO loginDto)
        {
            if (loginDto == null)
            {
                throw new ArgumentNullException(nameof(loginDto));
            }

            User user = await _userService.GetUserByEmailAsync(loginDto.Email);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

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