using ADEPT_API.LIBRARY.Exceptions.Interface;
using System.Net;

namespace ADEPT_API.Exceptions
{
    public class AlreadyExistsException : AdeptException
    {
        public AlreadyExistsException(string pErrorCode, string pMessage) : base(pErrorCode, pMessage, HttpStatusCode.Conflict) { }
    }
}
