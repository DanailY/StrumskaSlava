namespace StrumskaSlava.Data.Models
{
    using System.Collections.Generic;

    using StrumskaSlava.Data.Common.Models;

    public class Receipt : BaseModel<string>
    {
        public Receipt()
        {
            this.Orders = new List<Order>();
        }

        public List<Order> Orders { get; set; }

        public string RecipientId { get; set; }

        public ApplicationUser Recipient { get; set; }
    }
}
