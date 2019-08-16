namespace StrumskaSlava.Web.Middlewares
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using StrumskaSlava.Common;
    using StrumskaSlava.Data.Models;

    public class SeedAdminUserMiddleware
    {
        private readonly RequestDelegate next;

        public SeedAdminUserMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = GlobalConstants.AdminUsername,
                    Email = GlobalConstants.AdminEmail,
                    FirstName = GlobalConstants.AdminFirstName,
                    LastName = GlobalConstants.AdminLastName,
                };

                string userPassword = GlobalConstants.AdminPassword;

                user.EmailConfirmed = true;

                var createPowerUser = await userManager.CreateAsync(user, userPassword);

                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }
            }

            await this.next(context);
        }
    }
}
