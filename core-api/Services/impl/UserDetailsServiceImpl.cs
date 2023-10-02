using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using core_api.Models; // Replace with your actual model namespace

namespace core_api.Services
{
    public class UserDetailsServiceImpl : IUserDetailsService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserDetailsServiceImpl(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> LoadUserByUsername(string username)
        {
            // Find the user by username using UserManager
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new UsernameNotFoundException("No user found");
            }

            return user;
        }
    }
}
