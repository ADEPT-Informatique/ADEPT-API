using ADEPT_API.DATACONTRACTS.Dto.Users.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADEPT_API.DATABASE.Models.Users
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Roles Role { get; set; }
    }
}
