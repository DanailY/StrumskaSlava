namespace StrumskaSlava.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Common.Models;

    public class FootballPlayer : BaseModel<string>
    {
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
