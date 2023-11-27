using backend.Models;

namespace backend.Repositories
{
    public class UserRepository
    {
        private DatabaseContext _context;
        public UserRepository(DatabaseContext context) { _context = context; }

        public int GetNumberOfUsers()
        {
            var numberOfUsers = _context.users.Count(x => x.userid == 2);
            return numberOfUsers;
        }
    }
}
