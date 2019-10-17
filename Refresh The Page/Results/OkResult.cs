using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Refresh_The_Page.Results
{
    public class OkResult : IHttpActionResult
    {
        public static readonly HttpStatusCode CODE = HttpStatusCode.OK;
        public static readonly string MESSAGE = "Success";
        
        private readonly Response response;
        private readonly HttpRequestMessage request;


        public OkResult(string data, HttpRequestMessage request)
        {
            this.response = new Response()
            {
                StatusCode = OkResult.CODE,
                Message = OkResult.MESSAGE,
                Data = data
            };
            this.request = request;
        }

        public OkResult(HttpRequestMessage request)
        {
            this.response = new Response()
            {
                StatusCode = OkResult.CODE,
                Message = OkResult.MESSAGE
            };
            this.request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            HttpResponseMessage httpResponse = new HttpResponseMessage()
            {
                Content = new ObjectContent(typeof(Response), this.response, new JsonMediaTypeFormatter() { SerializerSettings = settings }),
                RequestMessage = this.request
            };
            return Task.FromResult(httpResponse);
        }
    }
}