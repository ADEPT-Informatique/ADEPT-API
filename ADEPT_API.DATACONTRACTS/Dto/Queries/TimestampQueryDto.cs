using System.Runtime.Serialization;

namespace ADEPT_API.DATACONTRACTS.Dto.Queries
{
    [DataContract]
    public class TimestampQueryDto
    {
        [DataMember]
        public long MinTimestampUtc { get; set; }

        [DataMember]
        public long MaxTimestampUtc { get; set; }
    }
}
