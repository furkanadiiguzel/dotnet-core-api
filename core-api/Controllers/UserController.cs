using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public UserController(AppDbContext appDbContext){
            _authContext = appDbContext;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserController userObj)
        {
            if(userObj ==null)
            {
                return BadRequest();
            }
            var user = await _authContext.Users.FirstOrDefaultAsync(u => u.Username == userObj.Username && u.Password == userObj.Password);
        }
       
    }
}
