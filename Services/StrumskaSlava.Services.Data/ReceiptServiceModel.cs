namespace StrumskaSlava.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class ReceiptServiceModel : IMapFrom<Receipt>, IMapTo<Receipt>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<OrderServiceModel> Orders { get; set; }

        public string RecipientId { get; set; }

        public StrumskaSlavaUserServiceModel Recipient { get; set; }
    }
}
