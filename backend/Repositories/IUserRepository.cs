using backend.Data.Models;

namespace backend.Repositories
{
    public interface IUserRepository
    {
        int GetNumberOfUsers();
        Task<IEnumerable<DbUser>> GetAllUsersAsync();
        Task<DbUser> GetUserByIdAsync(int id);
        Task<DbUser> GetUserByEmailAsync(string email);
        Task AddUserAsync(DbUser user);
        Task UpdateUserAsync(DbUser user);
        Task DeleteUserAsync(int id);
    }
}
