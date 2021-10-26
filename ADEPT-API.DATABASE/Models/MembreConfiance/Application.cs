using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATACONTRACTS.Models.MembreConfiance.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADEPT_API.DATABASE.Models.MembreConfiance
{
    public class Application
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public ApplicationStates State { get; set; }

        public virtual ICollection<ApplicationQuestion> ApplicationQuestions { get; set; }

        public long CreatedTimestampUtc { get; set; }

        [ForeignKey(nameof(Reviewer))]
        public Guid? ReviewerUserId { get; set; }

        public virtual User Reviewer { get; set; }

        public long? ReviewedTimestampUtc { get; set; }
    }
}
