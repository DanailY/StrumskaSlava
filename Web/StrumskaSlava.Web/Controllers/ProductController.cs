namespace StrumskaSlava.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Services;
    using StrumskaSlava.Web.ViewModels.Product.All;

    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<ProductAllViewModel> allProducts = await this.productService.GetAllProducts().Select(product => new ProductAllViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Picture = product.Picture,
                ProductType = product.ProductType.Name,
            }).ToListAsync();

            return this.View(allProducts);
        }
    }
}