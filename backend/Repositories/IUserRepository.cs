using backend.DTOs;
using backend.Models;
using backend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Data.Models;

namespace backend.Repositories
{
    public interface IUserRepository
    {
        int GetNumberOfUsers();
        Task<IEnumerable<DbUser>> GetAllUsersAsync();
        Task<DbUser> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(DbUser user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
