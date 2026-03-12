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
    }
}
