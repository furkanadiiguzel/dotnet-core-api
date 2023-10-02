using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace core_api
{
    public class JwtUtil
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtUtil(IConfiguration configuration)
        {
            // Load JWT settings from appsettings.json or configuration
            _secretKey = configuration["JwtSettings:Secret"];
            _issuer = configuration["JwtSettings:Issuer"];
            _audience = configuration["JwtSettings:Audience"];
        }

        public string GenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Adjust token expiration as needed
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, GetValidationParameters(), out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                // Token validation failed
                return null;
            }
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secretKey)),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                   StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
