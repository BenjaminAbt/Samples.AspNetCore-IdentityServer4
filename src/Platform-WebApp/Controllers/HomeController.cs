using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_PortalWebApp.ViewModels;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk.ApiModels;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_PortalWebApp.Controllers
{
    public class HomeController : AuthorizedBaseController
    {
        private readonly TodoApiClient _todoApiClient;

        public HomeController(TodoApiClient todoApiClient)
        {
            _todoApiClient = todoApiClient;
        }

        [AllowAnonymous]
        [Route("", Name = "Home")]
        public IActionResult Home()
        {
            return View("~/Views/Home/Home.cshtml");
        }

        [Route("Tasks", Name = "Tasks")]
        public async Task<IActionResult> Tasks()
        {
            IList<TaskApiModel> tasks = await _todoApiClient.GetTasksAsync();
            TasksViewModel viewModel = new TasksViewModel { TaskApiModels = tasks };

            return View("~/Views/Home/Tasks.cshtml", viewModel);
        }

        [Route("Claims", Name = "Claims")]
        public IActionResult Claims()
        {
            return View("~/Views/Home/Claims.cshtml");
        }

        [Route("Logout", Name = "Logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
