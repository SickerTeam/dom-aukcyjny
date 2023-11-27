using AutoMapper;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[Route("users/{id}")]
        //public IActionResult GetUserById(int id)
        //{
        //    var user = _userService.GetUser(id);
        //    return Ok(user);
        //}

        [HttpGet]
        [Route("users")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }
    }
}
