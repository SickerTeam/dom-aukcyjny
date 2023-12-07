using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Identity;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public UserService(IUserRepository userRepository, IMapper mapper, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationService = authenticationService;
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

        public async Task<UserDTO> AddUserAsync(UserRegistrationDTO userDto)
        {
            try
            {
            var user = _mapper.Map<User>(userDto);
            var result = await _userRepository.AddUserAsync(user);

            if (result != null)
            {
                await _authenticationService.RegisterUserAsync(userDto);
                return _mapper.Map<UserDTO>(user);
            }
            else
            {
                throw new Exception("User creation failed");
            }
        }
        catch (Exception ex)
        {
           throw new Exception("User creation failed", ex);     
        }
        
        
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
            if (user == null) return;

            await _userRepository.DeleteUserAsync(user.Id);
        }

        public async Task<string> LoginUserAsync(UserLoginDTO loginDTO)
        {
            return await _authenticationService.LoginUserAsync(loginDTO);
        }

        public async Task LogoutUserAsync(int id)
        {
            await _authenticationService.LogoutUserAsync(id);
        }
    }

}
