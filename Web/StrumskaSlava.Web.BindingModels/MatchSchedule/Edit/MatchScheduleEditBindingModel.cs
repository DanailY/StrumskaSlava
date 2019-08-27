using AutoMapper;
using StrumskaSlava.Common;
using StrumskaSlava.Services.Data;
using StrumskaSlava.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrumskaSlava.Web.BindingModels.MatchSchedule.Edit
{
    public class MatchScheduleEditBindingModel : IMapTo<MatchScheduleServiceModel>
    {
        [Required]
        public string HomeTeam { get; set; }

        [Required]
        public string GuestTeam { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        public int HomeTeamScore { get; set; }

        public int GuestTeamScore { get; set; }
    }
}
