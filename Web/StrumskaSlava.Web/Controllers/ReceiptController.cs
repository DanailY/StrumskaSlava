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
    using StrumskaSlava.Services;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using StrumskaSlava.Web.ViewModels.Receipt.Details;
    using StrumskaSlava.Web.ViewModels.Receipt.Profile;

    public class ReceiptController : BaseController
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            ReceiptServiceModel receiptServiceModel = await this.receiptService.GetAll()
                .SingleOrDefaultAsync(receipt => receipt.Id == id);

            ReceiptDetailsViewModel receiptDetailsViewModel = receiptServiceModel.To<ReceiptDetailsViewModel>();

            return this.View(receiptDetailsViewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<ReceiptServiceModel> receiptsFromDb = await this.receiptService
                .GetAllByRecepientId(userId)
                .ToListAsync();

            List<ReceiptProfileViewModel> receiptsForCurrentUser = receiptsFromDb
                .Select(receipt => receipt.To<ReceiptProfileViewModel>()).ToList();

            return this.View(receiptsForCurrentUser);
        }
    }
}
