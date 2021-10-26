using System;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.Users
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public int StudentNumber { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public virtual StudyProgramDto Program { get; set; }
    }
}
