using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.Models
{
    [Index(nameof(FireBaseID))]
    public class User
    {
        public int Id { get; set; }
        public string FireBaseID { get; set; }

        public string Username {get; set;}

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual List<UserRole> Roles { get; set; }
    }
}
