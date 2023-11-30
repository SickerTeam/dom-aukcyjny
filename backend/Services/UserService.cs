using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

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

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            User user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task AddUserAsync(UserRegisterationDTO userDto)
        {
            var user = new User
            {
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

            user.Id = userDto.Id;
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
