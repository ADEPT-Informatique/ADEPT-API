
using ADEPT_API.DATACONTRACTS.Dto.Discord.Enums;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.Discord.Operations.Requests
{
    [DataContract]
    class DiscordStatusUpdateRequestDto
    {
        [DataMember]
        public DiscordStatuses Type { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string CreatedByUserId { get; set; }
        [DataMember]
        public string AffectedUserId { get; set; }
        [DataMember]
        public long Duration { get; set; }
    }
}
