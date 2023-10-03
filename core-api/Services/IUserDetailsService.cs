using System.Threading.Tasks;
using core_api.Models; // Replace with your actual model namespace

namespace core_api.Services
{
    public interface IUserDetailsService
    {
        Task<ApplicationUser> LoadUserByUsername(string username);
    }
}
