using System;
using System.Collections.Generic;
using core_api.Models; // Replace with your actual model namespace

namespace core_api.Services
{
    public interface IUserService
    {
        ResultUserDto CreateUser(User user, List<UserRole> userRoles);

        ResultUserDto GetUserByUsername(string username);
    }
}
