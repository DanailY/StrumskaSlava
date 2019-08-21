namespace StrumskaSlava.Services.Data
{
    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class OrderStatusServiceModel : IMapFrom<OrderStatus>, IMapTo<OrderStatus>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
