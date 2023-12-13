using backend.DTOs;
using backend.Data.Models;

namespace backend.Services
{
    public interface IUserService
    {
        int GetNumberOfUsers();
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(UserCreationDTO userDto);
        Task<DbUser> GetUserByEmailAsync(string email);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(int id);
    }
}
