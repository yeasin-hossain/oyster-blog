using System.Net;
using System;

namespace oyster_blog
{
    public class CommonErrorException : Exception
    {
        public HttpStatusCode? StatusCode { get; set; }

        public CommonErrorException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }

        public CommonErrorException(HttpStatusCode statusCode, string message, params object[] args)
            : base(string.Format(message, args))
        {
            StatusCode = statusCode;
        }
    }
}
