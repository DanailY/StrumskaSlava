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
    using StrumskaSlava.Web.ViewModels.Receipt.All;

    public class ReceiptController : AdministrationController
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [HttpGet]
        [Route("/Administration/Receipt/All")]
        public async Task<IActionResult> All()
        {

            List<ReceiptServiceModel> receiptsFromDb = await this.receiptService
                .GetAll().ToListAsync();

            List<ReceiptAllViewModel> receiptsForCurrentUser = receiptsFromDb
                .Select(receipt => receipt.To<ReceiptAllViewModel>()).ToList();

            return this.View(receiptsForCurrentUser);
        }
    }
}