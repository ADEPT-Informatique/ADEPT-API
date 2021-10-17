using ADEPT_API.LIBRARY.Exceptions.Interface;
using System.Net;

namespace ADEPT_API.LIBRARY.Exceptions
{
    public class AlreadyAppliedException : AdeptException
    {
        public AlreadyAppliedException(string pEntityName, string pMessage) : base("ERR_ALREADYAPPLIED", pMessage, HttpStatusCode.BadRequest)
        {
            base.ErrorCode = $"{base.ErrorCode}_{pEntityName}";
        }
    }
}
