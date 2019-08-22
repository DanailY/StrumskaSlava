namespace StrumskaSlava.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StrumskaSlava.Data;
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class ReceiptService : IReceiptService
    {
        private readonly ApplicationDbContext context;
        private readonly IOrderService orderService;

        public ReceiptService(ApplicationDbContext context, IOrderService orderService)
        {
            this.context = context;
            this.orderService = orderService;
        }

        public async Task<string> CreateReceipt(string recepientId)
        {
            Receipt receipt = new Receipt
            {
                CreatedOn = DateTime.UtcNow,
                RecipientId = recepientId,
            };

            await this.orderService.SetOrdersToReceipt(receipt);

            foreach (var order in receipt.Orders)
            {
                await this.orderService.CompleteOrder(order.Id);
            }

            this.context.Receipts.Add(receipt);
            await this.context.SaveChangesAsync();

            return receipt.Id;
        }

        public IQueryable<ReceiptServiceModel> GetAll()
        {
            return this.context.Receipts.To<ReceiptServiceModel>();
        }

        public IQueryable<ReceiptServiceModel> GetAllByRecepientId(string recepientId)
        {
            return this.context.Receipts
                .Where(receipt => receipt.RecipientId == recepientId)
                .To<ReceiptServiceModel>();
        }
    }
}
