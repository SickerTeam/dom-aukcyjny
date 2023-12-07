using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public AuthController(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegistrationDTO registrationDto)
    {
        try
        {
            var user = _mapper.Map<User>(registrationDto);
            var token = await _authenticationService.RegisterUserAsync(registrationDto);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "An error occured while registering the user" });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDTO loginDto)
    {
        try
        {
            var token = await _authenticationService.LoginUserAsync(loginDto);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
}
