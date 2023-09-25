using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using core_api.Context; 
using core_api.Models; 
using core_api.Helpers;





namespace core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            var user = await _authContext.Users.FirstOrDefaultAsync(u =>
                u.Username == userObj.Username && u.Password == userObj.Password);

            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            return Ok(new { Message = "Login Success" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            var user = await _authContext.Users.FirstOrDefaultAsync(u => u.Username == userObj.Username);

            if (user != null)
            {
                return BadRequest(new { Message = "User already exists" });
            }

            // Assuming you have a DbSet<User> in your AppDbContext
            userObj.Password = PasswordHashing.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";
            _authContext.Users.Add(userObj);
            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "User created successfully" });
        }
    }
}
