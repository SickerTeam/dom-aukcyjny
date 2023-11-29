using backend.DTOs;
using backend.Models;
using backend.Repositories;
using backend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) { _userRepository = userRepository; }        

        public int GetNumberOfUsers()
        {
            return _userRepository.GetNumberOfUsers();
        }

        //public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        //{
        //    var users = await _context.users.ToListAsync();
        //    return users.Select(user => new UserDTO
        //    {
        //        Id = user.userid,
        //        Email = user.email,
        //        //Password = user.pass,
        //        FirstName = user.firstName,
        //        LastName = user.lastName,
        //        Bio = user.bio,
        //        Country = user.country,
        //        Link = user.personal_link
        //    });
        //}

        //public async Task<UserDTO> GetUserByIdAsync(int id)
        //{
        //    var user = await _context.users.FindAsync(id);
        //    return user == null ? null : new UserDTO
        //    {
        //        Id = user.userid,
        //        Email = user.email,
        //        //Password = user.pass,
        //        FirstName = user.firstName,
        //        LastName = user.lastName,
        //        Bio = user.bio,
        //        Country = user.country,
        //        Link = user.personal_link
        //    };
        //}

        //public async Task AddUserAsync(UserDTO userDto)
        //{
        //    var user = new user
        //    {
        //        userid = userDto.Id,
        //        email = userDto.Email,
        //        //pass = userDto.Password,
        //        firstName = userDto.FirstName,
        //        lastName = userDto.LastName,
        //        bio = userDto.Bio,
        //        country = userDto.Country,
        //        personal_link = userDto.Link
        //    };

        //    _context.users.Add(user);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateUserAsync(UserDTO userDto)
        //{
        //    var user = await _context.users.FindAsync(userDto.Id);
        //    if (user == null) return;

        //    user.email = userDto.Email;
        //    //user.pass = userDto.Password;
        //    user.firstName = userDto.FirstName;
        //    user.lastName = userDto.LastName;
        //    user.bio = userDto.Bio;
        //    user.country = userDto.Country;
        //    user.personal_link = userDto.Link;

        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteUserAsync(int id)
        //{
        //    var user = await _context.users.FindAsync(id);
        //    if (user == null) return;

        //    _context.users.Remove(user);
        //    await _context.SaveChangesAsync();
        //}
    }
}
