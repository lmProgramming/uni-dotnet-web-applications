
using Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using Identity.Data;
using Microsoft.AspNetCore.Identity;


namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ArticleDbContext _context;
        private readonly TokenService _tokenService;

        private readonly PasswordHasher<IdentityUser> _passwordHasher = new PasswordHasher<IdentityUser>();

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == loginModel.Username);
            if (user != null)
            {
                var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginModel.Password);
                if (verificationResult == PasswordVerificationResult.Success)
                {
                    var token = _tokenService.GenerateToken(user.Id, "Admin");
                    return Ok(new { Token = token });
                }
            }

            return Unauthorized();
        }
    }
}
