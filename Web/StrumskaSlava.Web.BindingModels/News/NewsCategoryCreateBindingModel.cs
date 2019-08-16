namespace StrumskaSlava.Web.BindingModels.News
{
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class NewsCategoryCreateBindingModel : IMapTo<NewsCategoryServiceModel>
    {
        [Required]
        public string Name { get; set; }
    }
}
