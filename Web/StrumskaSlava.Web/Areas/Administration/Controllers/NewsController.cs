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
    using StrumskaSlava.Web.BindingModels.News;

    public class NewsController : AdministrationController
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
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

        [HttpGet("/Administration/News/Create")]
        public async Task<IActionResult> CreateNews()
        {
            return this.View("Create");
        }

        [HttpPost("/Administration/News/Create")]
        public async Task<IActionResult> CreateNews(NewsCreateBindingModel newsCreateBindingModel)
        {
            //NewsServiceModel NewsServiceModel = new NewsServiceModel
            //{
            //    Name = newsCreateBindingModel.Name,
            //};

            //await this.newsService.CreateNewsCategory(newsCategoryServiceModel);

            return this.Redirect("/");
        }
    }
}