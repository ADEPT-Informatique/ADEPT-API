using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ADEPT_API.DATABASE.Models.Users
{
    [Index(nameof(FireBaseID))]
    public class User
    {
        public Guid Id { get; set; }
        public string FireBaseID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public virtual List<UserRole> Roles { get; set; }


        public User()
        {
            Roles = new List<UserRole>();
        }
    }
}
