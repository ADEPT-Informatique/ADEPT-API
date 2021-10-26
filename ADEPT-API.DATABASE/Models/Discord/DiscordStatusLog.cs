using ADEPT_API.DATABASE.Models.Discord.Enums;
using ADEPT_API.DATABASE.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADEPT_API.DATABASE.Models.Discord
{

    public class DiscordStatusLog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DiscordStatuses Type { get; set; }

        public string Reason { get; set; }

        [ForeignKey(nameof(AffectedUser))]
        public Guid AffectedUserId { get; set; }
        public virtual User AffectedUser { get; set; }

        public long? Duration { get; set; }

        [ForeignKey(nameof(CreatedByUser))]
        public Guid CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        [Required]
        public long CreatedTimestampUtc { get; set; }

        [ForeignKey(nameof(ReversionLog))]
        public Guid ReservionLogId { get; set; }
        public virtual DiscordStatusLog ReversionLog { get; set; }

    }
}
