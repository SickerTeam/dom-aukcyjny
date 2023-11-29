using backend.DTOs;
using backend.Models;
using backend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public int GetNumberOfUsers()
        {
            var numberOfUsers = _context.users.Count();
            return numberOfUsers;
        }
    }
}
