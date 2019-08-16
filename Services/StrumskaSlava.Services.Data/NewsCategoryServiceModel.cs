namespace StrumskaSlava.Services.Data
{
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class NewsCategoryServiceModel : IMapFrom<NewsCategory>, IMapTo<NewsCategory>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
