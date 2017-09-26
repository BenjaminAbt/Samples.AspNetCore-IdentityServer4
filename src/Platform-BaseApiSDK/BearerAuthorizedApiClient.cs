using System.Net.Http.Headers;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK
{
    public class BearerAuthorizedApiClient : RestApiHttpClient
    {
        public BearerAuthorizedApiClient(string token)
        {
            this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}