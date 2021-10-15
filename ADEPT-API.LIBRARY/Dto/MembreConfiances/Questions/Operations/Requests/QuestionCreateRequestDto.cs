using System.Runtime.Serialization;

namespace ADEPT_API.LIBRARY.Dto.MembreConfiances.Questions.Operations.Requests
{
    [DataContract]
    public class QuestionCreateRequestDto
    {
        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public bool IsActivated { get; set; }
    }
}
