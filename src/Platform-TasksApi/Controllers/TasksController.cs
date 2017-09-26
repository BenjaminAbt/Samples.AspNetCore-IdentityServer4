using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk.ApiModels;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApi.Controllers
{
    [Authorize]
    [Route("Api/Tasks")]
    public class TasksController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync()
        {
            var demoItems = new List<TaskApiModel>();
            {
                demoItems.Add(new TaskApiModel(1, "Update GitHub", "Lorem ipsum"));
                demoItems.Add(new TaskApiModel(2, "Write BlogPost", "Lorem ipsum"));
                demoItems.Add(new TaskApiModel(3, "Follow @abt_benjamin on Twitter", "Lorem ipsum"));
            }

            IActionResult result = Ok(demoItems);
            return await Task.FromResult(result);
        }
    }
}
