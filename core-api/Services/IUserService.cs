using System.Collections.Generic;
using System.Threading.Tasks;
using core_api.Dtos;
using core_api.Models;

namespace core_api.Services
{
    public interface IUserService
    {
        Task<ResultUserDto> CreateUserAsync(ApplicationUser user, List<string> roles, string password);
        Task<ResultUserDto> GetUserByUsernameAsync(string username);
    }
}
