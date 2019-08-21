namespace StrumskaSlava.Web.ViewModels.Product.Delete
{

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class ProductDeleteProductTypeViewModel : IMapFrom<ProductTypeServiceModel>
    {
        public string Name { get; set; }
    }
}
