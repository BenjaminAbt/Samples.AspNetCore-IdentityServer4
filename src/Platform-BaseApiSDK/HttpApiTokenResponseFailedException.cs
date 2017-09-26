using System;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK
{
    public class HttpApiTokenResponseFailedException : Exception
    {
        public HttpApiTokenResponseFailedException(string message) : base(message)
        {

        }
    }
}