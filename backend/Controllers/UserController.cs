using AutoMapper;
using backend.Services;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
   [ApiController]
   [Route("users")]
   public class UserController : ControllerBase
   {
      private readonly IUserService _userService;
      private readonly IMapper _mapper;

      public UserController(IUserService userService, IMapper mapper)
      {
         _userService = userService;
         _mapper = mapper;
      }

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
      public async Task<IActionResult> AddUser(UserDTO userDto)
      {
         await _userService.AddUserAsync(userDto);
         return Ok();
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateUser(int id, UserDTO userDto)
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
