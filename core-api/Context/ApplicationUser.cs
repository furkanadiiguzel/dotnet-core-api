using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace core_api
{
    public class ApplicationUser : IdentityUser
    {
        // Add additional user properties here
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }
        public string Phone { get; set; }
        public string Profile { get; set; }

        public bool Enabled { get; set; } = true;

        // If needed, you can define relationships to other entities here

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, IdentityConstants.ApplicationScheme);
            // Add custom claims if needed
            return userIdentity;
        }
        
    }
}
