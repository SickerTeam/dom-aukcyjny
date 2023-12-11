using backend.DTOs;

namespace backend.Services 
{
    public interface IAuthenticationService
    {
        Task<string> RegisterUserAsync(UserRegistrationDTO userRegistrationDTO);
        Task<string> LoginUserAsync(UserLoginDTO userLoginDTO);
    }
}