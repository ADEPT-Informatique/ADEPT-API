using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADEPT_API.DATABASE.Models.MembreConfiance
{
    public class ApplicationQuestion
    {
        [ForeignKey(nameof(Application))]
        public Guid ApplicationId { get; set; }

        public Application Application { get; set; }

        [ForeignKey(nameof(Question))]
        public Guid QuestionId { get; set; }

        public Question Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
