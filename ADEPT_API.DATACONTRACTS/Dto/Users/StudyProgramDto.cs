using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ADEPT_API.DATACONTRACTS.Dto.Users
{
    [DataContract]
    public class StudyProgramDto
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
