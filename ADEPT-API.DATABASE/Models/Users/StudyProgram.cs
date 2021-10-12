using System;
using System.ComponentModel.DataAnnotations;

namespace ADEPT_API.DATABASE.Models.Users
{
    public class StudyProgram
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
