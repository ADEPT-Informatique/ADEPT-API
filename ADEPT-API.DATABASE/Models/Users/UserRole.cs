using ADEPT_API.DATABASE.Models.Users.Enums;
using System;

namespace ADEPT_API.DATABASE.Models.Users
{
    public class UserRole
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Roles Role { get; set; }
    }
}
