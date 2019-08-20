namespace StrumskaSlava.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using StrumskaSlava.Services.Data;

    public interface INewsService
    {
        Task<bool> CreateNewsCategory(NewsCategoryServiceModel newsCategoryServiceModel);

        Task<bool> CreateNews(NewsServiceModel newsServiceModel);

        Task<bool> Create(NewsServiceModel newsServiceModel);

        Task<bool> Delete(string id);

        Task<bool> Edit(string id, NewsServiceModel newsServiceModel);

        IQueryable<NewsCategoryServiceModel> GetAllNewsCategory();

        IQueryable<NewsServiceModel> GetAllNews();

        IQueryable<NewsServiceModel> GetLastThreeNews();

        Task<NewsServiceModel> GetById(string id);

        Task<NewsCategoryServiceModel> GetCategoryByName(string name);
    }
}
