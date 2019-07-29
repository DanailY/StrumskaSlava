namespace StrumskaSlava.Web.Areas.Administration.Controllers
{
    using StrumskaSlava.Common;
    using StrumskaSlava.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
