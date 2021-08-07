namespace Astronomyfi.Web.Areas.Administration.Controllers
{
    using Astronomyfi.Common;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area(GlobalConstants.AdministratorAreaName)]
    public class AdministrationController : Controller
    {
    }
}
