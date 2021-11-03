using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.Users
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [IgnoreDataMember]
        public string firebaseId { get; set; }

        [DataMember]
        public int StudentNumber { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public StudyProgramDto Program { get; set; }

        [IgnoreDataMember]
        public IEnumerable<UserRoleDto> Roles { get; set; }
    }
}
