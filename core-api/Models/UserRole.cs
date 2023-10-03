using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core_api.Models;
using Microsoft.AspNetCore.Identity;

namespace core_api // Replace with your actual namespace
{
    public class UserRole 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; } // Change the data type to string

        public virtual User User { get; set; }

        [ForeignKey("RoleId")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
