using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_PortalWebApp.Controllers
{
    [Authorize]
    public abstract class AuthorizedBaseController : Controller { }
}