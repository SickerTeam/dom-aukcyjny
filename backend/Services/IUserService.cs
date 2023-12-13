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
        Task AddUserAsync(UserCreationDTO userDto);
        Task<User> GetUserByEmailAsync(string email);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(int id);
    }
}
