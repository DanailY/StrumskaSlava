namespace StrumskaSlava.Services
{
    using System;
    using System.Threading.Tasks;

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

        public async Task<bool> CreateNewsCategory(NewsCategoryServiceModel newsCategoryServiceModel)
        {
            NewsCategory newsCategory = new NewsCategory
            {
                Name = newsCategoryServiceModel.Name,
            };

            this.context.NewsCategories.Add(newsCategory);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}