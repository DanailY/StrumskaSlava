namespace StrumskaSlava.Web.ViewModels.LeagueTable
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class LeagueTableViewModel : IMapFrom<LeagueTableServiceModel>
    {
        public string Id { get; set; }

        public string TeamName { get; set; }

        public int MatchesPlayed { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }

        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public int Points { get; set; }
    }
}
