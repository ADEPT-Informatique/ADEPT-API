using ADEPT_API.DATABASE.Models.Discord.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Dto.Discord.Operations.Requests
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
