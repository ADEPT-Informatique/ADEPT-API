using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int StudentNumber { get; set; }
        public string DiscordId { get; set; }
        public string FullName { get; set; }

        [ForeignKey(nameof(Program))]
        public Guid? ProgramId { get; set; }
        public virtual StudyProgram Program { get; set; }

        public User()
        {
            Roles = new List<UserRole>();
        }
    }
}
