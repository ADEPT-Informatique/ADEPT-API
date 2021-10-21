using ADEPT_API.DATACONTRACTS.Validations.Commons;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests
{
    [DataContract]
    public class ApplicationUpdateRequestDto
    {
        [DataMember, AdeptRequired]
        public IEnumerable<ApplicationQuestionUpdateRequestDto> Questions { get; set; }
    }
}
