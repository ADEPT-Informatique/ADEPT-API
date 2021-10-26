using ADEPT_API.DATACONTRACTS.Validations.Commons;
using System;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests
{
    [DataContract]
    public class ApplicationQuestionCreateRequestDto
    {
        [DataMember, AdeptValidGuid]
        public Guid QuestionId { get; set; }

        [DataMember, AdeptRequired]
        public string Answer { get; set; }
    }
}
