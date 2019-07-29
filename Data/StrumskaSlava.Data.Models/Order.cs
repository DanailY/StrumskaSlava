namespace StrumskaSlava.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Common.Models;

    public class Order : BaseModel<string>, IDeletableEntity
    {
        public DateTime IssuedOn { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
