
using Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using Identity.Data;


namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ArticleDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var userId = _context.Users.FirstOrDefault(u => u.UserName == loginModel.Username && u.PasswordHash == loginModel.Password)?.Id;
            if (userId is not null)
            {
                var token = _tokenService.GenerateToken(userId, "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
