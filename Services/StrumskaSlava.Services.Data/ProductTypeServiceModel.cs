namespace StrumskaSlava.Services.Data
{
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class ProductTypeServiceModel : IMapFrom<ProductType>, IMapTo<ProductType>
    {
        public string Name { get; set; }
    }
}
