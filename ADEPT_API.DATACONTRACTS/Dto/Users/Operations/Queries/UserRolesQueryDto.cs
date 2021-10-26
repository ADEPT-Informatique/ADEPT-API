using ADEPT_API.DATACONTRACTS.Dto.Users.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.Users.Operations.Queries
{
    [DataContract]
    public class UserRolesQueryDto
    {
        [DataMember]
        public IEnumerable<Roles> Roles { get; set; }
    }
}
