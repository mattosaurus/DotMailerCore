using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBaseClient
{
    /// <summary>
    /// POCO to represent an API Exception
    /// https://github.com/twilio/twilio-csharp/blob/master/src/Twilio/Exceptions/ApiException.cs
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// More info if any was provided
        /// </summary>
        public string MoreInfo { get; }

        /// <summary>
        /// Create a ApiException with message
        /// </summary>
        /// <param name="message">Exception message</param>
        public ApiException(string message) : base (message) { }

        /// <summary>
        /// Create an ApiException from another Exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="exception">Exception to copy detatils from</param>
        public ApiException(string message, Exception exception) : base(message, exception) { }

        /// <summary>
        /// Create an ApiException
        /// </summary>
        /// <param name="status">HTTP status code</param>
        /// <param name="message">Error message</param>
        /// <param name="moreInfo">More info if provided</param>
        /// <param name="exception">Original exception</param>
        public ApiException(
            int status,
            string message,
            string moreInfo,
            Exception exception = null
        ) : base(message, exception)
        {
            Status = status;
            MoreInfo = moreInfo;
        }
    }
}
