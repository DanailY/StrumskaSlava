namespace StrumskaSlava.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using StrumskaSlava.Common;
    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.ViewModels.Order.Cart;

    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IReceiptService receiptService;

        public OrderController(IOrderService orderService, IReceiptService receiptService)
        {
            this.orderService = orderService;
            this.receiptService = receiptService;
        }

        [Authorize]
        [HttpGet(Name = "Cart")]

        public async Task<IActionResult> Cart()
        {
            List<OrderCartViewModel> orders = await this.orderService.GetAll()
                .Where(order => order.OrderStatus.Name == GlobalConstants.OrderStatusActive
                && order.UserId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .To<OrderCartViewModel>()
                .ToListAsync();

            return this.View(orders);
        }

        [Authorize]
        [HttpPost]
        [Route("/Order/Cart/Complete")]
        public async Task<IActionResult> Complete()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            string receiptId = await this.receiptService.CreateReceipt(userId);

            return this.Redirect($"/Receipt/Details/{receiptId}");
        }

        [Authorize]
        [Route("/Order/{id}/Quantity/Reduce")]
        public async Task<IActionResult> Reduce(string id)
        {
            await this.orderService.ReduceQuantity(id);

            return this.Ok();
        }

        [Authorize]
        [Route("/Order/{id}/Quantity/Increase")]
        public async Task<IActionResult> Increase(string id)
        {
            await this.orderService.IncreaseQuantity(id);

            return this.Ok();
        }
    }
}