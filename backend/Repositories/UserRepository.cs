using backend.DTOs;
using backend.Models;
using backend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BitchDatabaseContext _context;

        public UserRepository(BitchDatabaseContext context)
        {
            _context = context;
        }

        public int GetNumberOfUsers()
        {
            var numberOfUsers = _context.users.Count(x => x.Id == 2);
            return numberOfUsers;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
        return await _context.users.FindAsync(id);
        }


        public async Task AddUserAsync(User user)
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.users.FindAsync(id);
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
