namespace StrumskaSlava.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Common.Models;
    using StrumskaSlava.Data.Models.Enums;

    public class Product : BaseModel<string>
    {
        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        public decimal Price { get; set; }

        public SizeType Size { get; set; }

        public int Quantity { get; set; }
    }
}
