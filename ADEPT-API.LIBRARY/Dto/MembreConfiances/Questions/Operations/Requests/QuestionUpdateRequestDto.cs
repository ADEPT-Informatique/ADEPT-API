using ADEPT_API.LIBRARY.Validations.Commons;
using System.Runtime.Serialization;

namespace ADEPT_API.LIBRARY.Dto.MembreConfiances.Questions.Operations.Requests
{
    [DataContract]
    public class QuestionUpdateRequestDto
    {
        [DataMember, AdeptRequired]
        public string Content { get; set; }

        [DataMember]
        public bool IsActivated { get; set; }
    }
}
