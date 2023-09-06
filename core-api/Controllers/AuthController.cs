// Controllers/AuthController.cs
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var token = await _authService.AuthenticateAsync(model.Email, model.Password);

        if (token == null)
            return Unauthorized();

        return Ok(new { token });
    }
}
