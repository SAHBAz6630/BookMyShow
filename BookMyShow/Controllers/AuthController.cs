using BookMyShow.DTOs;
using BookMyShow.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
   
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            _authService.Register(dto);
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var token = _authService.Login(dto);
            return Ok(new { token });
        }
    }
}
