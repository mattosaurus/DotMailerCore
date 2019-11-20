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
        public int HttpStatus { get; }

        /// <summary>
        /// URI request was made to
        /// </summary>
        public string RequestUri { get; }

        /// <summary>
        /// Method type of request
        /// </summary>
        public string RequestMethod { get; }

        /// <summary>
        /// Parameters of request
        /// </summary>
        public string RequestParameters { get; }

        /// <summary>
        /// Returned response body
        /// </summary>
        public string ResponseContent { get; }

        public ApiException(
            int httpStatus,
            string requestUri,
            string requestMethod,
            string requestParameters,
            string responseContent,
            string message,
            Exception exception
            ) : base(message, exception)
        {
            HttpStatus = httpStatus;
            RequestUri = requestUri;
            RequestMethod = requestMethod;
            RequestParameters = requestParameters;
            ResponseContent = responseContent;
        }

        public ApiException(
            int httpStatus,
            string requestUri,
            string requestMethod,
            string requestParameters,
            string responseContent,
            string message
            ) : base(message)
        {
            HttpStatus = httpStatus;
            RequestUri = requestUri;
            RequestMethod = requestMethod;
            RequestParameters = requestParameters;
            ResponseContent = responseContent;
        }
    }
}
