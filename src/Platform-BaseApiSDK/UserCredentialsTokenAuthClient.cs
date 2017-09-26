using System.Threading.Tasks;
using IdentityModel.Client;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK
{
    public class UserCredentialsTokenAuthClient
    {
        private readonly string _endpoint;
        private readonly string _clientId;
        private readonly string _clientSecret;

        protected TokenResponse TokenResponse;

        public UserCredentialsTokenAuthClient(string endpoint, string clientId, string clientSecret)
        {
            _endpoint = endpoint;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<TokenResponse> AuthAsync(string username, string password, string targetClientId)
        {
            DiscoveryResponse discoveryResponse = await DiscoveryClient.GetAsync(_endpoint);

            TokenClient tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _clientId, _clientSecret);
            TokenResponse response = tokenClient.RequestResourceOwnerPasswordAsync(username, password, targetClientId).Result;

            if (response.IsError)
            {
                throw new HttpApiTokenResponseFailedException(response.Error);
            }

            return response;
        }
    }
}