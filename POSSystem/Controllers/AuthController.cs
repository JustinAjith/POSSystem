using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSSystem.Models.DtoModels;
using POSSystem.Services.Interfaces;

namespace POSSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(RegisterUser user)
        {
            var result = await _authService.CreateUserAsync(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var result = await _authService.Login(request);
            if (result == null) return BadRequest("Usrname or Password is incorrect");

            return Ok(result);
        }

        [Authorize]
        [HttpGet("login-user")]
        public string LoginUser()
        {
            return "Login Success";
        }
    }
}
