using backend.DTOs;

namespace backend.Services 
{
    public interface IAuthenticationService
    {
        Task<string> RegisterUserAsync(UserCreationDTO userRegistrationDTO);
        Task<string> LoginUserAsync(UserLoginDTO userLoginDTO);
    }
}