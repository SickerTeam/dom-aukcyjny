using backend.DTOs;
using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IUserService
    {
        int GetNumberOfUsers();
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(UserRegistrationDTO userDto);
        Task<User> GetModelById(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<UserDTO> AddUserAsync(UserRegistrationDTO userDto);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(int id);
    }
}
