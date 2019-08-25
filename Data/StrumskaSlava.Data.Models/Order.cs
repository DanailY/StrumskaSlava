namespace StrumskaSlava.Data.Models
{

    using StrumskaSlava.Data.Common.Models;

    public class Order : BaseModel<string>
    {
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public string ProductId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string OrderId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

    }
}
