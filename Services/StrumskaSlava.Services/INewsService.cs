namespace StrumskaSlava.Services
{
    using System.Threading.Tasks;

    using StrumskaSlava.Services.Data;

    public interface INewsService
    {
        Task<bool> CreateNewsCategory(NewsCategoryServiceModel newsCategoryServiceModel);

        Task<bool> CreateNews(NewsServiceModel newsServiceModel);
    }
}
