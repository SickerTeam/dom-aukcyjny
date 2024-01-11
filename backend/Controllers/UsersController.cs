using backend.Services;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace backend.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class UsersController(IUserService userService) : ControllerBase
   {
      private readonly IUserService _userService = userService;

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
         IEnumerable<UserDTO> users = await _userService.GetUsersAsync();
         return Ok(users);
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetUserById(int id)
      {
         UserDTO user = await _userService.GetUserByIdAsync(id);
         return Ok(user);
      }

      [HttpPost]
      public async Task<IActionResult> AddUser(UserCreationDTO userDto)
      {
         await _userService.AddUserAsync(userDto);
         return Ok();
      }

      [HttpPut]
      public async Task<IActionResult> UpdateUser(int id, [FromBody] JsonPatchDocument<UserDTO> patchDoc)
      {
         if (patchDoc == null)
         {
           return BadRequest();
         }

         UserDTO? result = await _userService.UpdateUserAsync(id, patchDoc);

         if (result == null)
         {
           return NotFound();
         }

         return Ok(result);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteUser(int id)
      {
         await _userService.DeleteUserAsync(id);
         return Ok();
      }

      [HttpGet]
      public async Task<IActionResult> GetUsersInfo()
      {
         IEnumerable<UserInfoDTO> usersInfo = await _userService.GetUsersInfoAsync();
         return Ok(usersInfo);
      }
   }
}
