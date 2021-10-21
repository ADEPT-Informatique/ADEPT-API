using ADEPT_API.LIBRARY.Exceptions.Interface;
using System.Net;

namespace ADEPT_API.LIBRARY.Exceptions
{
    public class UserCreationFailureException : AdeptException
    {
        public UserCreationFailureException(string entityName, string message) : base("ERR_USERCREATIONFAILURE", message, HttpStatusCode.BadRequest)
        {
            base.ErrorCode = $"{base.ErrorCode}_{entityName}";
        }
    }
}
