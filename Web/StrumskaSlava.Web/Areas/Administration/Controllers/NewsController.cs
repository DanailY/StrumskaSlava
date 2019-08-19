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
    using StrumskaSlava.Web.ViewModels.News.Create;

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
    }
}