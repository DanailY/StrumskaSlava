namespace StrumskaSlava.Web.ViewModels.MatchSchedule.All
{
    using System;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class MatchScheduleAllViewModel : IMapFrom<MatchScheduleServiceModel>, IMapTo<MatchScheduleServiceModel>
    {
        public string Id { get; set; }

        public string HomeTeam { get; set; }

        public string GuestTeam { get; set; }

        public virtual string MatchStatus { get; set; }

        public DateTime MatchDate { get; set; }

        public int? HomeTeamScore { get; set; }

        public int? GuestTeamScore { get; set; }
    }
}
