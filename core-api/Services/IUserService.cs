using System;
using System.Collections.Generic;
using core_api.Models; // Replace with your actual model namespace
using core_api.Dtos;

namespace core_api.Services
{
    public interface IUserService
    {
        ResultUserDto CreateUser(User user, List<UserRole> userRoles);

        ResultUserDto GetUserByUsername(string username);
    }
}
