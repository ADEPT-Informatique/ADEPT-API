using System;
using System.Net;

namespace ADEPT_API.LIBRARY.Exceptions.Interface
{
    public abstract class AdeptException : Exception
    {
        protected AdeptException(string errorCode, string message, HttpStatusCode? httpStatus) : base(message)
        {
            _ = string.IsNullOrWhiteSpace(errorCode) ? throw new ArgumentNullException(nameof(errorCode)) : string.Empty;

            this.ErrorCode = !string.IsNullOrWhiteSpace(errorCode) ? errorCode : throw new ArgumentNullException(nameof(errorCode), $"{nameof(AdeptException)} was expecting a value for {nameof(errorCode)} but null or empty was provided");
            this.HttpStatus = httpStatus;
        }

        public string ErrorCode { get; set; }
        public HttpStatusCode? HttpStatus { get; set; }
    }
}
