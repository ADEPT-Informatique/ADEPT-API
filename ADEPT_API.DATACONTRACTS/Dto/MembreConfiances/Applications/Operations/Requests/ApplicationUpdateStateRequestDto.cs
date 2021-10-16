using ADEPT_API.DATACONTRACTS.Models.MembreConfiance.Enums;
using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Applications.Operations.Requests
{
    [DataContract]
    public class ApplicationUpdateStateRequestDto
    {
        [DataMember]
        public ApplicationStates State { get; set; }
    }
}
