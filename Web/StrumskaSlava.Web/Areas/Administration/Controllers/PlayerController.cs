namespace StrumskaSlava.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.BindingModels.FootballPlayer.Create;
    using StrumskaSlava.Web.ViewModels.FootballPlayer.Create;

    public class PlayerController : AdministrationController
    {
        private readonly IFootballPlayerService footballPlayerService;
        private readonly ICloudinaryService cloudinaryService;

        public PlayerController(IFootballPlayerService footballPlayerService, ICloudinaryService cloudinaryService)
        {
            this.footballPlayerService = footballPlayerService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var allPlayerPositions = await this.footballPlayerService.GetAllPlayerPosition().ToListAsync();

            this.ViewData["positions"] = allPlayerPositions
                .Select(position => new FootballPlayerCreatePlayerPositionViewModel
                {
                    Name = position.Name,
                })
                .ToList();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FootballPlayerCreateBindingModel footballPlayerCreateBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allPlayerPositions = await this.footballPlayerService.GetAllPlayerPosition().ToListAsync();

                this.ViewData["positions"] = allPlayerPositions
                    .Select(position => new FootballPlayerCreatePlayerPositionViewModel
                    {
                        Name = position.Name,
                    })
                    .ToList();
            }

            string pictureUrl = await this.cloudinaryService
               .UploadPictureAync(footballPlayerCreateBindingModel.Picture, footballPlayerCreateBindingModel.Name);

            FootballPlayerServiceModel footballPlayerServiceModel = footballPlayerCreateBindingModel.To<FootballPlayerServiceModel>();

            footballPlayerServiceModel.Picture = pictureUrl;

            await this.footballPlayerService.CreatePlayer(footballPlayerServiceModel);

            return this.Redirect("/");
        }
    }
}