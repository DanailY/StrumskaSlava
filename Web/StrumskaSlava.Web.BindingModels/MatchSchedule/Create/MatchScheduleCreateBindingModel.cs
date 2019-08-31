using AutoMapper;
using StrumskaSlava.Common;
using StrumskaSlava.Services.Data;
using StrumskaSlava.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrumskaSlava.Web.BindingModels.MatchSchedule.Create
{
    public class MatchScheduleCreateBindingModel : IMapTo<MatchScheduleServiceModel>, IMapFrom<MatchScheduleServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string HomeTeam { get; set; }

        [Required]
        public string GuestTeam { get; set; }

        public string MatchStatus => GlobalConstants.MatchStatusActive;

        [Required]
        public DateTime MatchDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<MatchScheduleCreateBindingModel, MatchScheduleServiceModel>()
                .ForMember(d => d.MatchStatus, opts => opts.MapFrom(origin => new MatchStatusServiceModel
                {
                    Name = origin.MatchStatus,
                }));
        }
    }
}
