using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using core_api.Context; 
using core_api.Models; 
using core_api.Helpers;
using System.Text;
using System;
using System.Text.RegularExpressions;

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
            //Check Username
            if(await CheckUserNameExistAsync(userObj.Username)){
                return BadRequest(new { Message = "Username already exists" });
            }
            //Check Email
            if(await CheckEmailExistAsync(userObj.Email)){
                return BadRequest(new { Message = "Email already exists" });
            }

            //Check Password Strenght

            var pass = CheckPasswordStrength(userObj.Password);
            if(!string.IsNullOrEmpty(pass)){
                return BadRequest(new { Message = pass.ToString() });
            }




            userObj.Password = PasswordHashing.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";
            _authContext.Users.Add(userObj);
            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "User created successfully" });

            
        }
        private Task<bool> CheckUserNameExistAsync(string username)
            => _authContext.Users.AnyAsync(u=>u.Username==username);

        private Task<bool> CheckEmailExistAsync(string email)
            => _authContext.Users.AnyAsync(u=>u.Email==email);

        private string CheckPasswordStrength(string password){
            StringBuilder sb = new StringBuilder();
            if(password.Length < 8 ){
                sb.Append("Password must be at least 8 characters long"+Environment.NewLine);
            }
            if(!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]")))
            {
                sb.Append("Password must contain at least one uppercase and lowercase letter"+Environment.NewLine);
            }
           
            return sb.ToString();
        }


        
    }
}
