using backend.DTOs;
using backend.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace backend.Services
{
    public interface IUserService
    {
        int GetNumberOfUsers();
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(UserCreationDTO userDto);
        Task<DbUser> GetUserByEmailAsync(string email);
        Task<UserDTO?> UpdateUserAsync(int id, JsonPatchDocument<UserDTO> patchDoc);
        Task DeleteUserAsync(int id);
    }
}
