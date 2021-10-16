using ADEPT_API.LIBRARY.Exceptions.Interface;
using System.Net;

namespace ADEPT_API.Exceptions
{
    public class AlreadyExistsException : AdeptException
    {
        public AlreadyExistsException(string pEntityName, string pMessage) : base("ERR_EXIST", pMessage, HttpStatusCode.Conflict) 
        {
            base.ErrorCode = $"{base.ErrorCode}_{pEntityName}";
        }
    }
}
