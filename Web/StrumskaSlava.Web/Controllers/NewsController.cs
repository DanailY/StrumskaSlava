namespace StrumskaSlava.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.ViewModels.News.Create;
    using StrumskaSlava.Web.ViewModels.News.Details;

    public class NewsController : Controller
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

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