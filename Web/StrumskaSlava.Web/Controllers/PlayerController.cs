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
    using StrumskaSlava.Web.ViewModels.FootballPlayer.Details;

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

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            PlayerDetailsViewModel playerDetailsViewModel = (await this.footballPlayerService.GetById(id)).To<PlayerDetailsViewModel>();

            if (playerDetailsViewModel == null)
            {
                //TODO: Error Handling
                return this.Redirect("/");
            }

            return this.View(playerDetailsViewModel);
        }
    }
}