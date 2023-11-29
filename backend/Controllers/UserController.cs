using AutoMapper;
using backend.Services;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet]
        [Route("users")]
        public IActionResult Get()
        {
            int users = _userService.GetNumberOfUsers();
            return Ok(users);
        }
    }
}
