using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Data.Models;

namespace backend.Repositories
{
    public class UserRepository(DatabaseContext context) : IUserRepository
    {
        private readonly DatabaseContext _context = context;

        public int GetNumberOfUsers()
        {
            int numberOfUsers = _context.Users.Count();
            return numberOfUsers;
        }

        public async Task<IEnumerable<DbUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<DbUser> GetUserByIdAsync(int id)
        {
            DbUser? user = await _context.Users.FindAsync(id);
            return user ?? throw new ArgumentException("User not found");
        }

        public async Task<DbUser> GetUserByEmailAsync(string email)
        {
            DbUser? dbUser = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return dbUser ?? throw new ArgumentException("User not found");
        }

        public async Task AddUserAsync(DbUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(DbUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(DbUser user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
