using System;
using System.Net;

namespace ADEPT_API.LIBRARY.Exceptions.Interface
{
    public abstract class AdeptException : Exception
    {
        protected AdeptException(string pErrorCode, string pMessage, HttpStatusCode? pHttpStatus) : base(pMessage)
        {
            _ = string.IsNullOrWhiteSpace(pErrorCode) ? throw new ArgumentNullException(nameof(pErrorCode)) : string.Empty;

            this.ErrorCode = !string.IsNullOrWhiteSpace(pErrorCode) ? pErrorCode : throw new ArgumentNullException($"{nameof(AdeptException)} was expecting a value for {nameof(pErrorCode)} but null or empty was provided");
            this.HttpStatus = pHttpStatus;
        }

        public string ErrorCode { get; set; }
        public HttpStatusCode? HttpStatus { get; set; }
    }
}
