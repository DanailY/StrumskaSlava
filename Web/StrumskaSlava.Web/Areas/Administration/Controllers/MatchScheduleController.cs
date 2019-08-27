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
    using StrumskaSlava.Web.BindingModels.MatchSchedule.Create;
    using StrumskaSlava.Web.BindingModels.MatchSchedule.Edit;
    using StrumskaSlava.Web.ViewModels.MatchSchedule.Delete;

    public class MatchScheduleController : AdministrationController
    {
        private readonly IMatchScheduleService matchScheduleService;

        public MatchScheduleController(IMatchScheduleService matchScheduleService)
        {
            this.matchScheduleService = matchScheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MatchScheduleCreateBindingModel matchScheduleCreateBindingModel)
        {
            MatchScheduleServiceModel matchScheduleServiceModel = matchScheduleCreateBindingModel.To<MatchScheduleServiceModel>();

            await this.matchScheduleService.CreateMatchSchedule(matchScheduleServiceModel);

            return this.Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var matchScheduleEditBindingModel = await this.matchScheduleService.GetById(id);

            if (matchScheduleEditBindingModel == null)
            {
                //TODO: Error Handling
                return this.Redirect("/");

            }

            MatchScheduleEditBindingModel match = new MatchScheduleEditBindingModel
            {
                HomeTeam = matchScheduleEditBindingModel.HomeTeam,
                GuestTeam = matchScheduleEditBindingModel.GuestTeam,
                HomeTeamScore = 0,
                GuestTeamScore = 0,
                MatchDate = matchScheduleEditBindingModel.MatchDate,
            };

            return this.View(match);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, MatchScheduleEditBindingModel matchScheduleEditBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                throw new ArgumentException();
            }

            MatchScheduleServiceModel matchScheduleServiceModel = matchScheduleEditBindingModel.To<MatchScheduleServiceModel>();

            await this.matchScheduleService.EditMatchSchedule(id, matchScheduleServiceModel);

            return this.Redirect($"/MatchSchedule/All");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var matchSchedule = await this.matchScheduleService.GetById(id);

            if (matchSchedule == null)
            {
                // TODO: Error Handling
                return this.Redirect("/MatchSchedule/All");
            }

            MatchScheduleDeleteViewModel matchScheduleDeleteViewModel = new MatchScheduleDeleteViewModel
            {
                HomeTeam = matchSchedule.HomeTeam,
                HomeTeamScore = matchSchedule.HomeTeamScore,
                GuestTeam = matchSchedule.GuestTeam,
                GuestTeamScore = matchSchedule.GuestTeamScore,
                MatchDate = matchSchedule.MatchDate,
            };

            return this.View(matchScheduleDeleteViewModel);
        }

        [HttpPost]
        [Route("/Administration/MatchSchedule/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            await this.matchScheduleService.Delete(id);

            return this.Redirect("/MatchSchedule/All");
        }
    }
}