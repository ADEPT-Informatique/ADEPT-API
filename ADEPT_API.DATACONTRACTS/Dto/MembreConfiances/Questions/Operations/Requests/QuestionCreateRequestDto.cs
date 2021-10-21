using ADEPT_API.DATACONTRACTS.Validations.Commons;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Requests
{
    [DataContract]
    public class QuestionCreateRequestDto
    {
        [DataMember, AdeptRequired]
        public string Content { get; set; }

        [DataMember]
        public bool IsActivated { get; set; }
    }
}
