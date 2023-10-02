using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core_api // Replace with your actual namespace
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserRoleId { get; set; }

        [ForeignKey("UserId")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("RoleId")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
