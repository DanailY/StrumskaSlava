﻿namespace StrumskaSlava.Data.Models
{
    using System;

    using StrumskaSlava.Data.Common.Models;

    public class MatchSchedule : BaseModel<string>
    {
        public string HomeTeam { get; set; }

        public string GuestTeam { get; set; }

        public string MatchStatusId { get; set; }

        public virtual MatchStatus MatchStatus { get; set; }

        public DateTime MatchDate { get; set; }

        public int? HomeTeamScore { get; set; }

        public int? GuestTeamScore { get; set; }
    }
}
