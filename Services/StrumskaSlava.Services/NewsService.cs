namespace StrumskaSlava.Services
{
    using System;
    using System.Linq;
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

        public async Task<bool> Create(NewsServiceModel newsServiceModel)
        {
            NewsCategory newsCategoryFromDb = this.context.NewsCategories
                .SingleOrDefault(newsCategory => newsCategory.Name == newsServiceModel.NewsCategory.Name);

            if (newsCategoryFromDb == null)
            {
                throw new ArgumentNullException(nameof(newsCategoryFromDb));
            }

            News news = newsServiceModel.To<News>();
            news.NewsCategory = newsCategoryFromDb;

            this.context.News.Add(news);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
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

        public async Task<bool> Delete(string id)
        {
            News newsFromDb = await this.context.News.SingleOrDefaultAsync(news => news.Id == id);

            this.context.Remove(newsFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, NewsServiceModel newsServiceModel)
        {
            NewsCategory newsCategoryFromDb = await this.context.NewsCategories
                .SingleOrDefaultAsync(newsCategory => newsCategory.Name == newsServiceModel.NewsCategory.Name);

            if (newsCategoryFromDb == null)
            {
                throw new ArgumentNullException(nameof(newsCategoryFromDb));
            }

            News newsFromDb = await this.context.News.SingleOrDefaultAsync(news => news.Id == id);

            if (newsFromDb == null)
            {
                throw new ArgumentNullException(nameof(newsFromDb));
            }

            newsFromDb.Title = newsServiceModel.Title;
            newsFromDb.Content = newsServiceModel.Content;
            newsFromDb.Picture = newsServiceModel.Picture;

            newsFromDb.NewsCategory = newsCategoryFromDb;

            this.context.Update(newsFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<NewsServiceModel> GetAllNews()
        {
            return this.context.News.To<NewsServiceModel>();
        }

        public IQueryable<NewsCategoryServiceModel> GetAllNewsCategory()
        {
            return this.context.NewsCategories.To<NewsCategoryServiceModel>();
        }

        public async Task<NewsServiceModel> GetById(string id)
        {
            return await this.context.News.To<NewsServiceModel>().SingleOrDefaultAsync(news => news.Id == id);
        }

        public async Task<NewsCategoryServiceModel> GetCategoryByName(string name)
        {
            return await this.context.NewsCategories.To<NewsCategoryServiceModel>().SingleOrDefaultAsync(categoryName => categoryName.Name == name);
        }

        public IQueryable<NewsServiceModel> GetLastThreeNews()
        {
            return this.context.News.OrderByDescending(news => news.CreatedOn).Take(3).To<NewsServiceModel>();
        }
    }
}