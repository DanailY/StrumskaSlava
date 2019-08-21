namespace StrumskaSlava.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using StrumskaSlava.Services.Data;

    public interface IProductService
    {
        Task<bool> Create(ProductServiceModel productServiceModel);

        Task<bool> CreateProductType(ProductTypeServiceModel productTypeServiceModel);

        Task<bool> Edit(string id, ProductServiceModel productServiceModel);

        Task<bool> Delete(string id);

        Task<ProductServiceModel> GetById(string id);

        IQueryable<ProductServiceModel> GetAllProducts(string criteria = null);

        IQueryable<ProductTypeServiceModel> GetAllProductTypes();
    }
}
