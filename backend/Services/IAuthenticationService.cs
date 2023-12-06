using backend.DTOs;

namespace backend.Services 
{
    public interface IAuthenticationService
    {
        Task<string> RegisterUserAsync(UserRegistrationDTO registrationDto);
        Task<string> LoginUserAsync(UserLoginDTO loginDto);
        Task LogoutUserAsync(int id);
    }
}