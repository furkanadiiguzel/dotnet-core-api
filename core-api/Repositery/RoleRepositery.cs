using System.Collections.Generic;
using System.Threading.Tasks;
using core_api.Models;
using Microsoft.EntityFrameworkCore;


namespace core_api.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByIdAsync(long id);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(long id);
    }

    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationUser _dbContext;

        public RoleRepository(ApplicationUser dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> GetRoleByIdAsync(long id)
        {
            return await _dbContext.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            _dbContext.Entry(role).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRoleAsync(long id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null)
            {
                return false;
            }

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
