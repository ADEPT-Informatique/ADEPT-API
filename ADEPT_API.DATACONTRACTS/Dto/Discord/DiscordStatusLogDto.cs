using ADEPT_API.DATACONTRACTS.Dto.Discord.Enums;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using System;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.Discord
{
    [DataContract]
    public class DiscordStatusLogDto
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public DiscordStatuses Type { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public UserDto AffectedUser { get; set; }
        [DataMember]
        public long? Duration { get; set; }
        [DataMember]
        public UserDto CreatedByUser { get; set; }
        [DataMember]
        public long CreatedTimestampUtc { get; set; }
        [DataMember]
        public DiscordStatusLogDto ReversionLog { get; set; }
    }
}
