using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Refresh_The_Page.Results
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }

        public override string ToString()
        {
            return $"Status Code: {this.StatusCode}\n Message: {this.Message}\n";
        }
    }
}