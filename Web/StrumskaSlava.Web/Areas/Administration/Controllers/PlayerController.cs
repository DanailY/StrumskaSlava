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
    using StrumskaSlava.Web.BindingModels.FootballPlayer.Edit;
    using StrumskaSlava.Web.ViewModels.FootballPlayer.Create;
    using StrumskaSlava.Web.ViewModels.FootballPlayer.Delete;
    using StrumskaSlava.Web.ViewModels.FootballPlayer.Edit;
    using StrumskaSlava.Web.ViewModels.Product.Delete;

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

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            FootballPlayerEditBindingModel footballPlayerEditBindingModel = (await this.footballPlayerService.GetById(id))
                .To<FootballPlayerEditBindingModel>();

            if (footballPlayerEditBindingModel == null)
            {
                //TODO: Error Handling
                return this.Redirect("/");
            }

            var allPlayerPosition = await this.footballPlayerService.GetAllPlayerPosition().ToListAsync();

            this.ViewData["positions"] = allPlayerPosition
                    .Select(position => new FootballPlayerEditPlayerPositionViewModel
                    {
                        Name = position.Name,
                    })
                    .ToList();

            return this.View(footballPlayerEditBindingModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, FootballPlayerEditBindingModel footballPlayerEditBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allPlayerPosition = await this.footballPlayerService.GetAllPlayerPosition().ToListAsync();

                this.ViewData["positions"] = allPlayerPosition
                        .Select(position => new FootballPlayerEditPlayerPositionViewModel
                        {
                            Name = position.Name,
                        })
                        .ToList();

                return this.View(footballPlayerEditBindingModel);
            }

            string pictureUrl = await this.cloudinaryService
                .UploadPictureAync(footballPlayerEditBindingModel.Picture, footballPlayerEditBindingModel.Name);

            FootballPlayerServiceModel footballPlayerServiceModel = footballPlayerEditBindingModel.To<FootballPlayerServiceModel>();

            footballPlayerServiceModel.Picture = pictureUrl;

            await this.footballPlayerService.Edit(id, footballPlayerServiceModel);

            return this.Redirect($"/Player/Details/{id}");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            FootballPlayerDeleteViewModel footballPlayerDeleteViewModel = (await this.footballPlayerService.GetById(id))
                .To<FootballPlayerDeleteViewModel>();

            if (footballPlayerDeleteViewModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            var allPlayerPositions = await this.footballPlayerService.GetAllPlayerPosition().ToListAsync();

            this.ViewData["positions"] = allPlayerPositions.Select(position => new FootballPlayerDeletePlayerPositionViewModel
            {
                Name = position.Name,
            }).ToList();

            return this.View(footballPlayerDeleteViewModel);
        }

        [HttpPost]
        [Route("/Administration/Player/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            await this.footballPlayerService.Delete(id);

            return this.Redirect("/Player/All");
        }
    }
}