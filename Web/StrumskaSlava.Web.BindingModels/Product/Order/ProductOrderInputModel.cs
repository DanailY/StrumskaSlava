namespace StrumskaSlava.Web.BindingModels.Product.Order
{
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class ProductOrderInputModel : IMapTo<OrderServiceModel>
    {
        public string ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
