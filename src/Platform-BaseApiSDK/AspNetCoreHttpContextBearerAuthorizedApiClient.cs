using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK
{
    public class AspNetCoreHttpContextBearerAuthorizedApiClient : BearerAuthorizedApiClient
    {
        public AspNetCoreHttpContextBearerAuthorizedApiClient(IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor.HttpContext.GetTokenAsync("access_token").Result)
        {
           
        }
    }
}