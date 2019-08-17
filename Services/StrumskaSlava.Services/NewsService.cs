namespace StrumskaSlava.Services
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Data;
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext context;

        public NewsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateNews(NewsServiceModel newsServiceModel)
        {
            News news = newsServiceModel.To<News>();

            this.context.News.Add(news);
            int resutl = await this.context.SaveChangesAsync();

            return resutl > 0;
        }

        public async Task<bool> CreateNewsCategory(NewsCategoryServiceModel newsCategoryServiceModel)
        {
            NewsCategory newsCategory = newsCategoryServiceModel.To<NewsCategory>();

            this.context.NewsCategories.Add(newsCategory);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}