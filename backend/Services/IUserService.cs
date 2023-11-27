using backend.DTOs;
using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDTO userDto);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(int id);
    }
}
