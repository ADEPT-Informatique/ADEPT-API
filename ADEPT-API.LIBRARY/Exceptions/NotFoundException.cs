using ADEPT_API.LIBRARY.Exceptions.Interface;
using System.Net;

namespace ADEPT_API.Exceptions
{
    public class NotFoundException : AdeptException
    {
        public NotFoundException(string pEntityName, string pMessage) : base("ERR_NOTFOUND", pMessage, HttpStatusCode.NotFound) 
        {
            base.ErrorCode = $"{base.ErrorCode}_{pEntityName}";
        }
    }
}
