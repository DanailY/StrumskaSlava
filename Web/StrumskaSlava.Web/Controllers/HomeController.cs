namespace StrumskaSlava.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Services;
    using StrumskaSlava.Web.ViewModels.Home.Index;

    public class HomeController : BaseController
    {
        private readonly INewsService newsService;

        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            List<NewsHomeViewModel> topThreeNews = await this.newsService.GetLastThreeNews()
                .Select(news => new NewsHomeViewModel
                {
                    Id = news.Id,
                    Title = news.Title,
                    Picture = news.Picture,
                    NewsCategory = news.NewsCategory.Name,
                    CreatedOn = news.CreatedOn,
                })
                .ToListAsync();

            return this.View(topThreeNews);
        }

        public async Task<IActionResult> About()
        {
            return this.View();
        }

        public async Task<IActionResult> Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
