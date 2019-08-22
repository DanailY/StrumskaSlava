namespace StrumskaSlava.Web.ViewModels.Receipt.Details
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class ReceiptDetailsViewModel : IMapFrom<ReceiptServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Recipient { get; set; }

        public List<ReceiptDetailsOrderViewModel> Orders { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptServiceModel, ReceiptDetailsViewModel>()
                .ForMember(destination => destination.Recipient, opts => opts.MapFrom(origin => origin.Recipient.UserName));
        }
    }
}
