using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using core_api.Models; // Replace with your actual model namespace
using core_api.Services; // Replace with your actual service namespace

namespace core_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthenticateController(IUserService userService, IOptions<JwtSettings> jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings;
        }

        [HttpPost("generate-token")]
        public async Task<IActionResult> GenerateToken([FromBody] JwtRequest jwtRequest)
        {
            try
            {
                var user = await _userService.GetUserByUserNameAsync(jwtRequest.Username);

                if (user == null)
                {
                    return BadRequest("User not found");
                }

                var isValidPassword = _userService.VerifyPassword(user, jwtRequest.Password);

                if (!isValidPassword)
                {
                    return BadRequest("Invalid credentials");
                }

                var token = GenerateJwtToken(user);

                return Ok(new JwtResponse { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("current-user")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var username = User.Identity.Name;
                var user = await _userService.GetUserByUserNameAsync(username);

                if (user == null)
                {
                    return BadRequest("User not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "NORMAL") // Add roles as needed
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.Value.DurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
