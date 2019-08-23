namespace StrumskaSlava.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class FootballPlayerServiceModel : IMapFrom<FootballPlayer>, IMapTo<FootballPlayer>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public int PlayerPositionId { get; set; }

        public PlayerPosition PlayerPosition { get; set; }

        public string Picture { get; set; }

        public string Country { get; set; }

        public int PlayerNumber { get; set; }
    }
}
