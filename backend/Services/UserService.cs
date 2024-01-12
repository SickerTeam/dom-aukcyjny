using AutoMapper;
using backend.Data.Models;
using backend.DTOs;
using backend.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        protected internal ModelStateDictionary modelState = new();
        public int GetNumberOfUsers()
        {
            return _userRepository.GetNumberOfUsers();
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            IEnumerable<DbUser> users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            DbUser user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }
        
        public async Task AddUserAsync(UserCreationDTO userDto)
        {
            DbUser user = _mapper.Map<DbUser>(userDto);
            await _userRepository.AddUserAsync(user);
        }

        public async Task<DbUser> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<UserDTO?> UpdateUserAsync(int id, JsonPatchDocument<UserDTO> patchDoc)
        {
            DbUser user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;

            foreach (var operation in patchDoc.Operations)
            {
                if (operation.path == "id" || operation.path == "role" || operation.op != "replace")
                {
                    throw new InvalidOperationException("Updating one or more fields is not allowed.");
                }
            }

            UserDTO userDto = _mapper.Map<UserDTO>(user);
            patchDoc.ApplyTo(userDto, modelState);

            if (!modelState.IsValid) return null;
            
            _mapper.Map(userDto, user);
            await _userRepository.UpdateUserAsync(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            DbUser user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return;

            await _userRepository.DeleteUserAsync(user);
        }
    }
}