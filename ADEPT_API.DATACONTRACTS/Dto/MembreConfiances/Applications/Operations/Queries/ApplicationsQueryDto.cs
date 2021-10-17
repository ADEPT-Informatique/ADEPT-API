using ADEPT_API.DATACONTRACTS.Models.MembreConfiance.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ADEPT_API.DATACONTRACTS.Dto.Queries;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Queries
{
    [DataContract]
    public class ApplicationsQueryDto
    {
        [DataMember]
        public IEnumerable<Guid> Ids { get; set; }

        [DataMember]
        public IEnumerable<Guid> UserIds { get; set; }

        [DataMember]
        public IEnumerable<Guid?> ReviewerUserIds { get; set; }

        [DataMember]
        public IEnumerable<ApplicationStates> States { get; set; }

        [DataMember]
        public TimestampQueryDto CreatedTimestampUtcQuery { get; set; }
    }
}
