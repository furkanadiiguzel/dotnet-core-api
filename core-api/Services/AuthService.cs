// Services/AuthService.cs
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class AuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        // Authenticate user (validate credentials against the database)
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user != null && VerifyPasswordHash(password, user.PasswordHash))
        {
            // Generate JWT token
            var token = GenerateJwtToken(user);
            return token;
        }

        return null;
    }

    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
            // Add other claims as needed (e.g., roles)
        };

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(1), // Token expiration time
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private bool VerifyPasswordHash(string password, string passwordHash)
    {
        // Implement your password hashing and verification logic here
        // For security reasons, never store passwords in plain text
        // Use a secure password hashing library like BCrypt or Identity's PasswordHasher
        // Verify the password against the stored hash
        // Return true if the password is valid, otherwise return false
    }
}
