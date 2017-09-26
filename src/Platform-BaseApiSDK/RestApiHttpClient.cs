using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK
{
    public abstract class RestApiHttpClient : HttpClient, IRestApiHttpClient
    {
        public async Task<T> GetFromApiAsync<T>(string url)
        {
            HttpResponseMessage response = await base.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpApiRequestFailedException(response);
            }

            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public Task<IList<T>> GetCollectionFromApiAsync<T>( string url)
        {
            return GetFromApiAsync<IList<T>>(url);
        }
    }
}