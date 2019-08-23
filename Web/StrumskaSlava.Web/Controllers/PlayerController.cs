namespace StrumskaSlava.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using StrumskaSlava.Services;
    using StrumskaSlava.Web.ViewModels.FootballPlayer.All;
    using StrumskaSlava.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class PlayerController : BaseController
    {
        private readonly IFootballPlayerService footballPlayerService;

        public PlayerController(IFootballPlayerService footballPlayerService)
        {
            this.footballPlayerService = footballPlayerService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<FootballPlayerAllViewModel> allPlayers = await this.footballPlayerService
                .GetAllPlayers()
                .To<FootballPlayerAllViewModel>()
                .ToListAsync();

            return this.View(allPlayers);
        }
    }
}