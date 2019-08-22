namespace StrumskaSlava.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Identity;
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class StrumskaSlavaUserServiceModel : IdentityUser, IMapFrom<ApplicationUser>
    {
        public string FullName { get; set; }

        public List<OrderServiceModel> Orders { get; set; }
    }
}
