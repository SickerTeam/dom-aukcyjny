using backend.DTOs;
using backend.Models;
using backend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        //private DatabaseContext _context;
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public int GetNumberOfUsers()
        {
            var numberOfUsers = _context.users.Count(x => x.userid == 2);
            return numberOfUsers;
        }

        //public async Task<IEnumerable<User>> GetUsersAsync()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        //public async Task<User> GetUserByIdAsync(int id)
        //{
        //    return await _context.Users.FindAsync(x => x.userid == id);
        //}

        //public async Task AddUserAsync(User user)
        //{
        //    await _context.Users.AddAsync(user);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateUserAsync(User user)
        //{
        //    _context.Users.Update(user);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteUserAsync(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //}
    }
}
