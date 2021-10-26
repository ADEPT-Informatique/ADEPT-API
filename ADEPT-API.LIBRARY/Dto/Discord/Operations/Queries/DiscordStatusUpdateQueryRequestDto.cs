using ADEPT_API.DATABASE.Models.Discord.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Dto.Discord.Operations.Queries
{
    [DataContract]
    class DiscordStatusUpdateQueryRequestDto
    {
        [DataMember]
        public IEnumerable<string> AffectedIds { get; set; }
        [DataMember]
        public IEnumerable<string> CreatedByIds { get; set; }
        [DataMember]
        public IEnumerable<DiscordStatuses> Types { get; set; }
        [DataMember]
        public bool? IsReverted { get; set; }
        [DataMember]
        public bool? IsStillActive { get; set; }

    }
}
