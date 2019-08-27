namespace StrumskaSlava.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.ViewModels.MatchSchedule.All;

    public class MatchScheduleController : BaseController
    {
        private readonly IMatchScheduleService matchScheduleService;

        public MatchScheduleController(IMatchScheduleService matchScheduleService)
        {
            this.matchScheduleService = matchScheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {

            List<MatchScheduleAllViewModel> allGames = await this.matchScheduleService.GetAll()
                .OrderBy(date => date.MatchDate)
                .Select(game => new MatchScheduleAllViewModel
                {
                    Id = game.Id,
                    HomeTeam = game.HomeTeam,
                    GuestTeam = game.GuestTeam,
                    MatchStatus = game.MatchStatus.Name,
                    HomeTeamScore = game.HomeTeamScore,
                    GuestTeamScore = game.GuestTeamScore,
                    MatchDate = game.MatchDate,
                }).ToListAsync();

            return this.View(allGames);
        }
    }
}