namespace StrumskaSlava.Web.ViewModels.News.Delete
{
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class NewsDeleteNewsCategoryViewModel : IMapFrom<NewsCategoryServiceModel>
    {
        public string Name { get; set; }
    }
}
