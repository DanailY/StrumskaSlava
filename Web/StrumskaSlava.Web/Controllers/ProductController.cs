namespace StrumskaSlava.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.BindingModels.Product.Order;
    using StrumskaSlava.Web.ViewModels.Product.All;
    using StrumskaSlava.Web.ViewModels.Product.Details;

    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<ProductAllViewModel> allProducts = await this.productService.GetAllProducts().Select(product => new ProductAllViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Picture = product.Picture,
                ProductType = product.ProductType.Name,
            }).ToListAsync();

            return this.View(allProducts);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            ProductDetailsViewModel productDetailsViewModel = (await this.productService.GetById(id)).To<ProductDetailsViewModel>();

            if (productDetailsViewModel == null)
            {
                //TODO: Error Handling
                return this.Redirect("/");
            }

            return this.View(productDetailsViewModel);
        }

        [HttpPost(Name = "Order")]
        public async Task<IActionResult> Order(ProductOrderInputModel productOrderInputModel)
        {
            OrderServiceModel orderServiceModel = productOrderInputModel.To<OrderServiceModel>();

            orderServiceModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.orderService.CreateOrder(orderServiceModel);

            return this.Redirect("/Product/All");
        }
    }
}