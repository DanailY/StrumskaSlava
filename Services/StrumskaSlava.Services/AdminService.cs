namespace StrumskaSlava.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using StrumskaSlava.Common;
    using StrumskaSlava.Data;
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.BindingModels.AdminPanel;

    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<bool> Create(AdminCreateBindingModel adminCreateBindingModel)
        {
            var user = new ApplicationUser
            {
                UserName = adminCreateBindingModel.Username,
                Email = adminCreateBindingModel.Email,
                FirstName = adminCreateBindingModel.FirstName,
                LastName = adminCreateBindingModel.LastName,
            };

            string userPassword = adminCreateBindingModel.Password;

            user.EmailConfirmed = true;

            var createPowerUser = await this.userManager.CreateAsync(user, userPassword);

            bool result = false;

            if (createPowerUser.Succeeded)
            {
                await this.userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);

                result = true;
            }

            return result;
        }
    }
}
