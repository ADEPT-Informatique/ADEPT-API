using ADEPT_API.LIBRARY.Exceptions.Interface;
using System.Net;

namespace ADEPT_API.LIBRARY.Exceptions
{
    public class UnAuthorizedException : AdeptException
    {
        public UnAuthorizedException(string pEntityName, string pMessage) : base("ERR_UNAUTHORIZED", pMessage, HttpStatusCode.BadRequest)
        {
            base.ErrorCode = $"{base.ErrorCode}_{pEntityName}";
        }
    }
}
