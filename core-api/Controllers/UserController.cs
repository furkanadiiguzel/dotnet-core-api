using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using core_api.Models; // Replace with your actual model namespace
using core_api.Services; // Replace with your actual service namespace

namespace core_api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                // Create a list of roles and add a default role
                var roles = new List<UserRole>
                {
                    new UserRole { RoleName = "NORMAL" }
                };

                var result = await _userService.CreateUserAsync(user, roles);

                if (result.Success)
                {
                    return Ok(result.User);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{username}")]
        [Authorize]
        public async Task<IActionResult> GetUser(string username)
        {
            try
            {
                var result = await _userService.GetUserByUserNameAsync(username);

                if (result.Success)
                {
                    return Ok(result.User);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
