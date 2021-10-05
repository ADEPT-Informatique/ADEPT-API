using System;

namespace ADEPT_API.Exceptions.Interface
{
    public abstract class AdeptException : Exception
    {
        protected AdeptException(string pErrorCode, string pMessage) : base(pMessage)
        {
            _ = string.IsNullOrWhiteSpace(pErrorCode) ? throw new ArgumentNullException(nameof(pErrorCode)) : string.Empty;

            this.ErrorCode = !string.IsNullOrWhiteSpace(pErrorCode) ? pErrorCode : throw new ArgumentNullException($"{nameof(NotFoundException)} was expecting a value for {nameof(pErrorCode)} but null or empty was provided");
        }

        public string ErrorCode { get; set; }
    }
}
