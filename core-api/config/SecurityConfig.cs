using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace YourNamespace
{
    public class SecurityConfig
    {
        public static void ConfigureSecurityServices(IServiceCollection services)
        {
            // Add Identity
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Configure Identity options here
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            // JWT Authentication
            var key = Encoding.UTF8.GetBytes("YourSecretKey"); // Replace with your secret key
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "YourIssuer", // Replace with your issuer
                        ValidateAudience = true,
                        ValidAudience = "YourAudience", // Replace with your audience
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            // Handle authentication failed event
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            // Handle token validated event
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build());
            });

            // CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        public static void ConfigureSecurity(IApplicationBuilder app)
        {
            app.UseCors("MyPolicy");

            app.UseAuthentication();

            app.UseAuthorization();
        }
    }
}
