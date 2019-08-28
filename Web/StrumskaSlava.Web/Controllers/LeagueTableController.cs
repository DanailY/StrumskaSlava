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
    using StrumskaSlava.Web.ViewModels.LeagueTable;

    public class LeagueTableController : BaseController
    {
        private readonly ILeagueTableService leagueTableService;

        public LeagueTableController(ILeagueTableService leagueTableService)
        {
            this.leagueTableService = leagueTableService;
        }

        [HttpGet]
        public async Task<IActionResult> Ranking()
        {
            List<LeagueTableViewModel> leagueTable = await this.leagueTableService
                .GetAllTeams()
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalsFor - x.GoalsAgainst)
                .ThenByDescending(x => x.Wins)
                .ThenByDescending(x => x.Draws)
                .ThenBy(x => x.Losses)
                .ThenBy(x => x.TeamName)
                .To<LeagueTableViewModel>()
                .ToListAsync();

            return this.View(leagueTable);
        }
    }
}