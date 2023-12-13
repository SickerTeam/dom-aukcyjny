using AutoMapper;
using backend.Services;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class UsersController(IUserService userService, IMapper mapper) : ControllerBase
   {
      private readonly IUserService _userService = userService;
      private readonly IMapper _mapper = mapper;

      [HttpGet]
      [Route("count")]
      public IActionResult GetNumberOfUsers()
      {
         int users = _userService.GetNumberOfUsers();
         return Ok(users);
      }

      [HttpGet]
      public async Task<IActionResult> GetUsers()
      {
         var users = await _userService.GetUsersAsync();
         return Ok(users);
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetUserById(int id)
      {
         var user = await _userService.GetUserByIdAsync(id);
         return Ok(user);
      }

      [HttpPost]
      public async Task<IActionResult> AddUser(UserCreationDTO userDto)
      {
         await _userService.AddUserAsync(userDto);
         return Ok();
      }

      [HttpPut]
      public async Task<IActionResult> UpdateUser(UserDTO userDto)
      {
         await _userService.UpdateUserAsync(userDto);
         return Ok();
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteUser(int id)
      {
         await _userService.DeleteUserAsync(id);
         return Ok();
      }
   }
}
