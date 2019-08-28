namespace StrumskaSlava.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.BindingModels.LeagueTable;

    public class LeagueTableController : AdministrationController
    {
        private readonly ILeagueTableService leagueTableService;

        public LeagueTableController(ILeagueTableService leagueTableService)
        {
            this.leagueTableService = leagueTableService;
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            LeagueTableEditBindingModel leagueTableEditBindingModel = (await this.leagueTableService.GetById(id)).To<LeagueTableEditBindingModel>();

            if (leagueTableEditBindingModel == null)
            {
                //TODO: Error Handling
                return this.Redirect("/LeagueTable/Ranking");
            }

            return this.View(leagueTableEditBindingModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, LeagueTableEditBindingModel leagueTableEditBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/LeagueTable/Ranking/Edit/{id}");
            }

            LeagueTableServiceModel leagueTableServiceModel = leagueTableEditBindingModel.To<LeagueTableServiceModel>();

            await this.leagueTableService.Edit(id, leagueTableServiceModel);

            return this.Redirect($"/LeagueTable/Ranking");
        }
    }
}