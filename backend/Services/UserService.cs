using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public int GetNumberOfUsers()
        {
            return _userRepository.GetNumberOfUsers();
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return userDTOs;
        }

        // public async Task<UserDTO> GetUserByIdAsync(int id)
        // {
        //     User user = await _userRepository.GetUserByIdAsync(id);
        //     return new UserDTO(user.Id, user.Email, user.FirstName, user.LastName, user.Bio, user.Country, user.PersonalLink, UserRole.Admin);
        // }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            User user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task AddUserAsync(UserDTO userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Bio = userDto.Bio,
                Country = userDto.Country,
                PersonalLink = userDto.Link
            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
           var user = await _userRepository.GetUserByIdAsync(userDto.Id);
           if (user == null) return;

            user.Email = userDto.Email;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Bio = userDto.Bio;
            user.Country = userDto.Country;
            user.PersonalLink = userDto.Link;

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return;
            await _userRepository.DeleteUserAsync(user.Id);
        }
    }
}
