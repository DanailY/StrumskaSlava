namespace StrumskaSlava.Web.ViewModels.News.All
{
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class NewsAllViewModel : IMapFrom<NewsServiceModel>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Picture { get; set; }

        public string NewsCategory { get; set; }
    }
}
