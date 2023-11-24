using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public class UserService : IUserService
    {
        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        UserDTO IUserService.GetUser(int id)
        {
            throw new NotImplementedException();
        }

        IList<UserDTO> IUserService.GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
