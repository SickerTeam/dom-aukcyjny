using AutoMapper;
using backend.Data.Models;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

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
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }
        
        public async Task AddUserAsync(UserRegistrationDTO userDto)
        {
            var user = _mapper.Map<DbUser>(userDto);
            await _userRepository.AddUserAsync(user);

        }
        public async Task<User> GetModelById(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<UserDTO> AddUserAsync(UserRegistrationDTO userDto)
        {
            User user = null;
            try
            {
                user = _mapper.Map<User>(userDto);
                var result = await _userRepository.AddUserAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception("User creation failed", ex);
            }

            return _mapper.Map<UserDTO>(user);

        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(userDto.Id);
            if (user == null) return;

            _mapper.Map(userDto, user);
            // await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return;

            await _userRepository.DeleteUserAsync((int)user.Id);
        }
    }

}
