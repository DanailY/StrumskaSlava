namespace StrumskaSlava.Web.ViewModels.FootballPlayer.Delete
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class FootballPlayerDeleteViewModel : IMapFrom<FootballPlayerServiceModel>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public string PlayerPositionName { get; set; }

        public string Picture { get; set; }

        public string Country { get; set; }

        public int PlayerNumber { get; set; }
    }
}
