namespace StrumskaSlava.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Common;
    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.ViewModels.News.All;
    using StrumskaSlava.Web.ViewModels.News.Create;
    using StrumskaSlava.Web.ViewModels.News.Details;
    using X.PagedList;

    public class NewsController : BaseController
    {


        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> All(NewsViewModel model)
        {
            List<NewsAllViewModel> allNews = await this.newsService.GetAllNews()
                .OrderByDescending(order => order.CreatedOn)
                .Select(news => new NewsAllViewModel
                {
                    Id = news.Id,
                    Title = news.Title,
                    NewsCategory = news.NewsCategory.Name,
                    Picture = news.Picture,
                    CreatedOn = news.CreatedOn,
                }).ToListAsync();

            int pageNumber = model.PageNumber ?? GlobalConstants.DefaultPageNumber;

            var pageNewsViewMode = allNews.ToPagedList(pageNumber, GlobalConstants.DefaultPageSize);

            model.NewsAllIndexViewModel = pageNewsViewMode;

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            NewsDetailsViewModel newsDetailsViewModel = (await this.newsService.GetById(id)).To<NewsDetailsViewModel>();

            if (newsDetailsViewModel == null)
            {
                //TODO: Error Handling
                return this.Redirect("/");
            }

            return this.View(newsDetailsViewModel);
        }
    }
}