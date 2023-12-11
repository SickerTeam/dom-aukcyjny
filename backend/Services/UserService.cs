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
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<User> GetModelById(int id)
        {

            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(UserRegistrationDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            if (userDto.Id == null) return;
            var user = await _userRepository.GetUserByIdAsync((int)userDto.Id);
            if (user == null) return;

            _mapper.Map(userDto, user);
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null || user.Id == null) return;

            await _userRepository.DeleteUserAsync((int)user.Id);
        }
    }
}