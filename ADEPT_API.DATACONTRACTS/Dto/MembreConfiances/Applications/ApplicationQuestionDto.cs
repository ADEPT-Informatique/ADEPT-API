using System;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications
{
    [DataContract]
    public class ApplicationQuestionDto
    {
        [DataMember]
        public Guid QuestionId { get; set; }

        [DataMember]
        public Guid ApplicationId { get; set; }

        [DataMember]
        public string Answer { get; set; }
    }
}
