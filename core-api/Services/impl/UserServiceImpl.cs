using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using core_api.Models; 
using core_api.Dtos;
using core_api.Services;

namespace core_api.Services
{
    public class UserServiceImpl : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserServiceImpl(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<ResultUserDto> CreateUserAsync(ApplicationUser user, List<string> roles, string password)
        {
            var resultUserDto = new ResultUserDto();

            try
            {
                var existingUser = await _userManager.FindByNameAsync(user.UserName);
                if (existingUser != null)
                {
                    // User already exists
                    resultUserDto.Success = false;
                    resultUserDto.Errors = new List<string> { "User already exists." };
                }
                else
                {
                    // Create the user
                    var result = await _userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        // Add roles to the user
                        foreach (var roleName in roles)
                        {
                            if (await _roleManager.RoleExistsAsync(roleName))
                            {
                                await _userManager.AddToRoleAsync(user, roleName);
                            }
                        }

                        resultUserDto.Success = true;
                        resultUserDto.User = user;
                    }
                    else
                    {
                        resultUserDto.Success = false;
                        resultUserDto.Errors = result.Errors.Select(error => error.Description).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                resultUserDto.Success = false;
                resultUserDto.Errors = new List<string> { ex.Message };
            }

            return resultUserDto;
        }

        
        public async Task<ResultUserDto> GetUserByUsernameAsync(string username)
        {
            var resultUserDto = new ResultUserDto();

            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    resultUserDto.Success = true;
                    resultUserDto.User = user;
                }
                else
                {
                    resultUserDto.Success = false;
                    resultUserDto.Errors = new List<string> { "User not found." };
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                resultUserDto.Success = false;
                resultUserDto.Errors = new List<string> { ex.Message };
            }

            return resultUserDto;
        }
    }
}

        

    

