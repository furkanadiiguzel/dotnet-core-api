using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace core_api.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profile { get; set; }
        public bool Enabled { get; set; } = true;

        // Navigation property for user roles
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Question> Questions { get; set; }


        // Constructor
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
    }
}
