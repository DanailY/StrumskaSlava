using StrumskaSlava.Services.Data;
using StrumskaSlava.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrumskaSlava.Web.BindingModels.LeagueTable
{
    public class LeagueTableEditBindingModel : IMapTo<LeagueTableServiceModel>, IMapFrom<LeagueTableServiceModel>
    {
        [Required]
        public string TeamName { get; set; }

        [Required]
        public int MatchesPlayed { get; set; }

        [Required]
        public int Wins { get; set; }

        [Required]
        public int Draws { get; set; }

        [Required]
        public int Losses { get; set; }

        [Required]
        public int GoalsFor { get; set; }

        [Required]
        public int GoalsAgainst { get; set; }

        [Required]
        public int Points { get; set; }
    }
}
