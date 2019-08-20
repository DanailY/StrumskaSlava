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
    using StrumskaSlava.Web.BindingModels.News;
    using StrumskaSlava.Web.BindingModels.News.Edit;
    using StrumskaSlava.Web.ViewModels.News.Create;
    using StrumskaSlava.Web.ViewModels.News.Delete;

    public class NewsController : AdministrationController
    {
        private readonly INewsService newsService;
        private readonly ICloudinaryService cloudinaryService;

        public NewsController(INewsService newsService, ICloudinaryService cloudinaryService)
        {
            this.newsService = newsService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("/Administration/News/Category/Create")]
        public async Task<IActionResult> CreateCategoryNews()
        {
            return this.View("Category/Create");
        }

        [HttpPost("/Administration/News/Category/Create")]
        public async Task<IActionResult> CreateCategoryNews(NewsCategoryCreateBindingModel newsCategoryCreateBindingModel)
        {
            NewsCategoryServiceModel newsCategoryServiceModel = newsCategoryCreateBindingModel.To<NewsCategoryServiceModel>();

            await this.newsService.CreateNewsCategory(newsCategoryServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            var allNewsCategory = await this.newsService.GetAllNewsCategory().ToListAsync();

            this.ViewData["categories"] = allNewsCategory
                .Select(newsCategory => new NewsCreateNewsCategoryViewModel
                {
                    Name = newsCategory.Name,
                })
                .ToList();

            return this.View();
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(NewsCreateBindingModel newsCreateBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allNewsCategory = await this.newsService.GetAllNewsCategory().ToListAsync();

                this.ViewData["categories"] = allNewsCategory
                    .Select(newsCategory => new NewsCategoryCreateBindingModel
                    {
                        Name = newsCategory.Name,
                    })
                    .ToList();

                return this.View();
            }

            string pictureUrl = await this.cloudinaryService
                .UploadPictureAync(newsCreateBindingModel.Picture, newsCreateBindingModel.Title);

            NewsServiceModel newsServiceModel = newsCreateBindingModel.To<NewsServiceModel>();

            newsServiceModel.Picture = pictureUrl;


            await this.newsService.Create(newsServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            NewsEditBindingModel newsEditBindingModel = (await this.newsService.GetById(id)).To<NewsEditBindingModel>();

            if (newsEditBindingModel == null)
            {
                //TODO: Error Handling
                return this.Redirect("/");
            }

            var allNewsCategories = await this.newsService.GetAllNewsCategory().ToListAsync();

            this.ViewData["categories"] = allNewsCategories
                    .Select(newsCategories => new NewsCreateNewsCategoryViewModel
                    {
                        Name = newsCategories.Name,
                    })
                    .ToList();

            return this.View(newsEditBindingModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, NewsEditBindingModel newsEditBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allNewsCategories = await this.newsService.GetAllNewsCategory().ToListAsync();

                this.ViewData["categories"] = allNewsCategories
                    .Select(newsCategories => new NewsCreateNewsCategoryViewModel
                    {
                        Name = newsCategories.Name,
                    })
                    .ToList();

                return this.View(newsEditBindingModel);
            }

            string pictureUrl = await this.cloudinaryService
                .UploadPictureAync(newsEditBindingModel.Picture, newsEditBindingModel.Title);

            NewsServiceModel newsServiceModel = newsEditBindingModel.To<NewsServiceModel>();

            newsServiceModel.Picture = pictureUrl;

            await this.newsService.Edit(id, newsServiceModel);

            return this.Redirect($"/News/Details/{id}");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            NewsDeleteViewModel newsDeleteViewModel = (await this.newsService.GetById(id)).To<NewsDeleteViewModel>();

            if (newsDeleteViewModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            var allNewsCategory = await this.newsService.GetAllNewsCategory().ToListAsync();

            this.ViewData["categories"] = allNewsCategory
                .Select(newsCategory => new NewsDeleteNewsCategoryViewModel
                {
                    Name = newsCategory.Name,
                }).ToList();

            return this.View(newsDeleteViewModel);
        }

        [HttpPost]
        [Route("/Administration/News/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            await this.newsService.Delete(id);

            return this.Redirect("/News/All");
        }
    }
}