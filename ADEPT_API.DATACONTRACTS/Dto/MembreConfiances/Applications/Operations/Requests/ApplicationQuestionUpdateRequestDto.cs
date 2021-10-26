using ADEPT_API.DATACONTRACTS.Validations.Commons;
using System;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests
{
    [DataContract]
    public class ApplicationQuestionUpdateRequestDto
    {
        [DataMember, AdeptValidGuid(RefuseEmptyGuid = true)]
        public Guid ApplicationId { get; set; }

        [DataMember, AdeptValidGuid(RefuseEmptyGuid = true)]
        public Guid QuestionId { get; set; }

        [DataMember, AdeptRequired]
        public string Answer { get; set; }
    }
}
