using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace QuotesApp.Exception
{
    class HttpException : ApplicationException
    {
        public HttpException(HttpStatusCode statusCode) : base("Request failure, received code = " + statusCode)
        {

        }
    }
}
