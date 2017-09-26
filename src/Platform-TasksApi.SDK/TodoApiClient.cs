using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk.ApiModels;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk
{
    public class TodoApiClient
    {
        private readonly IRestApiHttpClient _restApiHttpClient;
        private readonly string _todoApiEndpoint;

        public TodoApiClient(IRestApiHttpClient restApiHttpClient, string todoApiEndpoint)
        {
            _restApiHttpClient = restApiHttpClient;
            _todoApiEndpoint = todoApiEndpoint;
        }

        public Task<IList<TaskApiModel>> GetTasksAsync()
        {
            return _restApiHttpClient.GetCollectionFromApiAsync<TaskApiModel>(_todoApiEndpoint + "/api/tasks");
        }
    }
}