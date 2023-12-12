
using backend.Models;
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
            var numberOfUsers = _context.Users.Count();
            return numberOfUsers;
        }

        public async Task<IEnumerable<DbUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<DbUser> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user ?? throw new ArgumentException("User not found");
        }

        public async Task AddUserAsync(DbUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return user ?? throw new ArgumentException("User not found");
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            // _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new ArgumentException("User not found");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
