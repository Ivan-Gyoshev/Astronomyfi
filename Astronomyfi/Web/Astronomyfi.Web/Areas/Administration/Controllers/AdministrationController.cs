namespace Astronomyfi.Web.Areas.Administration.Controllers
{
    using Astronomyfi.Common;
    using Astronomyfi.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
