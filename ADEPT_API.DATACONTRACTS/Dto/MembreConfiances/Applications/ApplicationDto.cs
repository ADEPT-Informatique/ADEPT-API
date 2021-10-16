using ADEPT_API.DATACONTRACTS.Dto.Users;
using ADEPT_API.DATACONTRACTS.Models.MembreConfiance.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications
{
    [DataContract]
    public class ApplicationDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public UserSummaryDto User { get; set; }

        [DataMember]
        public ApplicationStates States { get; set; }

        [DataMember]
        public IEnumerable<ApplicationQuestionDto> ApplicationQuestions { get; set; }

        [DataMember]
        public long CreatedTimestampUtc { get; set; }

        [DataMember]
        public UserSummaryDto ReviewerUser { get; set; }

        [DataMember]
        public long? ReviewedTimestampUtc { get; set; }
    }
}
