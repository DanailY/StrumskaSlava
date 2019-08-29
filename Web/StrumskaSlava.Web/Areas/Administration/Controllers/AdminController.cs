namespace StrumskaSlava.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services;
    using StrumskaSlava.Web.BindingModels.AdminPanel;

    public class AdminController : AdministrationController
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(AdminCreateBindingModel adminCreateBindingModel)
        {

            await this.adminService.Create(adminCreateBindingModel);

            return this.Redirect("/");
        }
    }
}