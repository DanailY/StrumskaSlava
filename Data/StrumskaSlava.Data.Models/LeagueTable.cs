namespace StrumskaSlava.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Common.Models;

    public class LeagueTable : BaseModel<string>
    {
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
