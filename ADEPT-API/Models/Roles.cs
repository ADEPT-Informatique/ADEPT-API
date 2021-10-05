using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Models
{

    public class UserRole
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }


        public UserRoles Role { get; set; }
    }


    // Higher = Better
    public enum UserRoles
    {
        Guest,
        Membre,
        OrganisateurTournoi,
        OrganisateurLAN,
        MembreConfiance,
        Admin
 
    }
}
