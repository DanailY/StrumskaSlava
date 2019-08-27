namespace StrumskaSlava.Web.ViewModels.MatchSchedule.Delete
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MatchScheduleDeleteViewModel
    {
        public string HomeTeam { get; set; }

        public string GuestTeam { get; set; }

        public DateTime MatchDate { get; set; }

        public int? HomeTeamScore { get; set; }

        public int? GuestTeamScore { get; set; }
    }
}
