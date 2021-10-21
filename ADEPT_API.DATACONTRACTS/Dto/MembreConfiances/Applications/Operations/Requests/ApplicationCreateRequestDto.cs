using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests
{
    [DataContract]
    public class ApplicationCreateRequestDto
    {
        [DataMember]
        public IEnumerable<ApplicationQuestionCreateRequestDto> ApplicationQuestions { get; set; }
    }
}
