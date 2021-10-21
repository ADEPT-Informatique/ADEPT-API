using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Queries
{
    [DataContract]
    public class QuestionsQueryDto
    {
        [DataMember]
        public IEnumerable<Guid> Ids { get; set; }

        [DataMember]
        public bool? IsActivated { get; set; }
    }
}
