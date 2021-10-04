using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }


        public int Role { get; set; }
    }


    // Higher = Better
    public enum UserRoles
    {
        Guest = 0,
        Membre = 10,
        MembreConfiance = 20,
        OrganisateurLAN = 25,
        Admin = 30
    }
}
