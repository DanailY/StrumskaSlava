namespace StrumskaSlava.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Common.Models;

    public class Product : BaseModel<string>
    {
        public string Name { get; set; }

        public string ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
