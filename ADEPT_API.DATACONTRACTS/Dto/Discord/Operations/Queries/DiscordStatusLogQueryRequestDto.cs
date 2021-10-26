using ADEPT_API.DATACONTRACTS.Dto.Discord.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.Discord.Operations.Queries
{
    [DataContract]
    public class DiscordStatusLogQueryRequestDto
    {
        [DataMember]
        public IEnumerable<Guid> AffectedIds { get; set; }
        [DataMember]
        public IEnumerable<Guid> CreatedByIds { get; set; }
        [DataMember]
        public IEnumerable<DiscordStatuses> Types { get; set; }
        [DataMember]
        public bool? IsReverted { get; set; }
        [DataMember]
        public bool? IsStillActive { get; set; }

    }
}
