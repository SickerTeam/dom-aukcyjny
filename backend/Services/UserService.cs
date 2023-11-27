using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) { _userRepository = userRepository; }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public int GetUsers()
        {
            return _userRepository.GetNumberOfUsers();
        }
    }
}
