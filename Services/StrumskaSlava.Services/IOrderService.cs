namespace StrumskaSlava.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Data;

    public interface IOrderService
    {
        Task<bool> CreateOrder(OrderServiceModel orderServiceModel);

        IQueryable<OrderServiceModel> GetAll();

        Task SetOrdersToReceipt(Receipt receipt);

        Task<bool> CompleteOrder(string orderId);

        Task<bool> ReduceQuantity(string orderId);

        Task<bool> IncreaseQuantity(string orderId);
    }
}
