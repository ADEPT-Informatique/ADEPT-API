using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.Users.Operations.Queries
{
    [DataContract]
    public class UsersQueryDto
    {
        [DataMember]
        public IEnumerable<Guid> Ids { get; set; }

        [DataMember]
        public IEnumerable<string> FirebaseIds { get; set; }

        [DataMember]
        public IEnumerable<int> StudentNumbers { get; set; }

        [DataMember]
        public IEnumerable<string> DiscordIds { get; set; }

        [DataMember]
        public IEnumerable<Guid> ProgramIds { get; set; }

        [DataMember]
        public UserRolesQueryDto UserRoles { get; set; }
    }
}
