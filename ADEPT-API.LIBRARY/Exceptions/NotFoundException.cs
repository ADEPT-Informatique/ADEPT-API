using ADEPT_API.LIBRARY.Exceptions.Interface;
using System.Net;

namespace ADEPT_API.Exceptions
{
    public class NotFoundException : AdeptException
    {
        public NotFoundException(string pErrorCode, string pMessage) : base(pErrorCode, pMessage, HttpStatusCode.NotFound) { }
    }
}
