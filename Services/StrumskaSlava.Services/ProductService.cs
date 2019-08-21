namespace StrumskaSlava.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Data;
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(ProductServiceModel productServiceModel)
        {
            ProductType productTypeFromDb = await this.context.ProductTypes
                .SingleOrDefaultAsync(productType => productType.Name == productServiceModel.ProductType.Name);

            if (productTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(productTypeFromDb));
            }

            Product product = AutoMapper.Mapper.Map<Product>(productServiceModel);
            product.ProductType = productTypeFromDb;

            this.context.Products.Add(product);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreateProductType(ProductTypeServiceModel productTypeServiceModel)
        {
            ProductType productType = productTypeServiceModel.To<ProductType>();

            this.context.ProductTypes.Add(productType);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            Product productFromDb = await this.context.Products.SingleOrDefaultAsync(product => product.Id == id);

            this.context.Products.Remove(productFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, ProductServiceModel productServiceModel)
        {
            ProductType productTypeFromDb =
                this.context.ProductTypes
                .SingleOrDefault(productType => productType.Name == productServiceModel.ProductType.Name);

            if (productTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(productTypeFromDb));
            }

            Product productFromDb = await this.context.Products.SingleOrDefaultAsync(product => product.Id == id);

            if (productFromDb == null)
            {
                throw new ArgumentNullException(nameof(productFromDb));
            }

            productFromDb.Name = productServiceModel.Name;
            productFromDb.Price = productServiceModel.Price;
            productFromDb.Picture = productServiceModel.Picture;
            productFromDb.Description = productServiceModel.Description;

            productFromDb.ProductType = productTypeFromDb;

            this.context.Products.Update(productFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<ProductServiceModel> GetAllProducts(string criteria = null)
        {
            return this.context.Products.To<ProductServiceModel>();
        }

        public IQueryable<ProductTypeServiceModel> GetAllProductTypes()
        {
            return this.context.ProductTypes.To<ProductTypeServiceModel>();
        }

        public async Task<ProductServiceModel> GetById(string id)
        {
            return await this.context.Products.To<ProductServiceModel>()
                .SingleOrDefaultAsync(product => product.Id == id);
        }
    }
}
