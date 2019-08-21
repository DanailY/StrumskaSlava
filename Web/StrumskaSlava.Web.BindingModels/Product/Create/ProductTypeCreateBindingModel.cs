namespace StrumskaSlava.Web.BindingModels.Product.Create
{
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class ProductTypeCreateBindingModel : IMapTo<ProductTypeServiceModel>
    {
        [Required]
        public string Name { get; set; }
    }
}
