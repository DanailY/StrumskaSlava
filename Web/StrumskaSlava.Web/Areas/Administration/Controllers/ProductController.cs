namespace StrumskaSlava.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.BindingModels.Product.Create;
    using StrumskaSlava.Web.BindingModels.Product.Edit;
    using StrumskaSlava.Web.ViewModels.Product.Create;
    using StrumskaSlava.Web.ViewModels.Product.Delete;
    using StrumskaSlava.Web.ViewModels.Product.Edit;

    public class ProductController : AdministrationController
    {
        private readonly IProductService productService;
        private readonly ICloudinaryService cloudinaryService;

        public ProductController(IProductService productService, ICloudinaryService cloudinaryService)
        {
            this.productService = productService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("/Administration/Product/Type/Create")]
        public async Task<IActionResult> CreateType()
        {
            return this.View("Type/Create");
        }

        [HttpPost("/Administration/Product/Type/Create")]
        public async Task<IActionResult> CreateType(ProductTypeCreateBindingModel productTypeCreateBindingModel)
        {
            ProductTypeServiceModel productTypeServiceModel = productTypeCreateBindingModel.To<ProductTypeServiceModel>();

            await this.productService.CreateProductType(productTypeServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            var allProductTypes = await this.productService.GetAllProductTypes().ToListAsync();

            this.ViewData["types"] = allProductTypes
                .Select(productType => new ProductCreateProductTypeViewModel
                {
                    Name = productType.Name,
                })
                .ToList();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateBindingModel productCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allProductTypes = await this.productService.GetAllProductTypes().ToListAsync();

                this.ViewData["types"] = allProductTypes
                    .Select(productType => new ProductCreateProductTypeViewModel
                    {
                        Name = productType.Name,
                    })
                    .ToList();

                return this.View();
            }

            string pictureUrl = await this.cloudinaryService
                .UploadPictureAync(productCreateInputModel.Picture, productCreateInputModel.Name);

            ProductServiceModel productServiceModel = AutoMapper.Mapper.Map<ProductServiceModel>(productCreateInputModel);

            productServiceModel.Picture = pictureUrl;


            await this.productService.Create(productServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            ProductEditBindingModel productEditInputModel = (await this.productService.GetById(id)).To<ProductEditBindingModel>();

            if (productEditInputModel == null)
            {
                //TODO: Error Handling
                return this.Redirect("/");
            }

            var allProductTypes = await this.productService.GetAllProductTypes().ToListAsync();

            this.ViewData["types"] = allProductTypes
                    .Select(productType => new ProductEditProductTypeViewModel
                    {
                        Name = productType.Name, 
                    })
                    .ToList(); ;

            return this.View(productEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ProductEditBindingModel productEditBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allProductTypes = await this.productService.GetAllProductTypes().ToListAsync();

                this.ViewData["types"] = allProductTypes
                    .Select(productType => new ProductEditProductTypeViewModel
                    {
                        Name = productType.Name,
                    })
                    .ToList();

                return this.View(productEditBindingModel);
            }

            string pictureUrl = await this.cloudinaryService
                .UploadPictureAync(productEditBindingModel.Picture, productEditBindingModel.Name);

            ProductServiceModel productServiceModel = AutoMapper.Mapper.Map<ProductServiceModel>(productEditBindingModel);

            productServiceModel.Picture = pictureUrl;

            await this.productService.Edit(id, productServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            ProductDeleteViewModel productDeleteViewModel = (await this.productService.GetById(id)
               ).To<ProductDeleteViewModel>();

            if (productDeleteViewModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            var allProductTypes = await this.productService.GetAllProductTypes().ToListAsync();

            this.ViewData["types"] = allProductTypes.Select(productType => new ProductCreateProductTypeViewModel
            {
                Name = productType.Name, 
            }).ToList();

            return this.View(productDeleteViewModel);
        }

        [HttpPost]
        [Route("/Administration/Product/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            await this.productService.Delete(id);

            return this.Redirect("/");
        }
    }
}