using System;
using System.Net;
using System.Net.Http;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK
{
    public class HttpApiRequestFailedException : Exception
    {
        public HttpResponseMessage Response { get; }
        public HttpStatusCode StatusCode => Response.StatusCode;


        public HttpApiRequestFailedException(HttpResponseMessage response)
        {
            Response = response;
        }
    }
}
