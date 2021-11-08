using ADEPT_API.DATACONTRACTS.Dto.Users.Enums;
using System;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.Users
{
    [DataContract]
    public class UserRoleDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Roles Role { get; set; }
    }
}
