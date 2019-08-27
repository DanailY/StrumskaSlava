namespace StrumskaSlava.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class MatchScheduleServiceModel : IMapFrom<MatchSchedule>, IMapTo<MatchSchedule>
    {
        public string Id { get; set; }

        public string HomeTeam { get; set; }

        public string GuestTeam { get; set; }

        public string MatchStatusId { get; set; }

        public MatchStatus MatchStatus { get; set; }

        public DateTime MatchDate { get; set; }

        public int? HomeTeamScore { get; set; }

        public int? GuestTeamScore { get; set; }
    }
}
