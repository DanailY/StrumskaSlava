namespace StrumskaSlava.Data.Models
{
    using System;

    public class MatchSchedule
    {
        public string Id { get; set; }

        public DateTime DateOfTheGame { get; set; }

        public string RivalTeam { get; set; }

        public string FinalResult { get; set; }
    }
}
