using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core_api // Replace with your actual namespace
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
