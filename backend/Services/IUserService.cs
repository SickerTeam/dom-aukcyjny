using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        IList<UserDTO> GetUsers();
        //public UserDTO CreateUser(UserDTO userDTO);
        //public UserDTO UpdateUser(UserDTO userDTO);


    }
}
