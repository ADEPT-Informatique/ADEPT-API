using System;
using System.Runtime.Serialization;

namespace ADEPT_API.LIBRARY.Dto.MembreConfiances.Questions
{
    [DataContract]
    public class QuestionDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public bool IsActivated { get; set; }
    }
}
