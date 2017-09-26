using System.Collections.Generic;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk.ApiModels;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_PortalWebApp.ViewModels
{
    public class TasksViewModel
    {
        public IList<TaskApiModel> TaskApiModels { get; set; }
    }
}
