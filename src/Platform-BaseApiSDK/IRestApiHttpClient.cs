using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK
{
    public interface IRestApiHttpClient
    {
        Task<T> GetFromApiAsync<T>(string url);
        Task<IList<T>> GetCollectionFromApiAsync<T>(string url);
    }
}
