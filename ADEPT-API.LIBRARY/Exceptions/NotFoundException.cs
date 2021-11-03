using ADEPT_API.LIBRARY.Exceptions.Interface;
using System.Net;

namespace ADEPT_API.Exceptions
{
    public class NotFoundException : AdeptException
    {
        public NotFoundException(string entityName, string message) : base("ERR_NOTFOUND", message, HttpStatusCode.NotFound) 
        {
            base.ErrorCode = $"{base.ErrorCode}_{entityName}";
        }
    }
}
