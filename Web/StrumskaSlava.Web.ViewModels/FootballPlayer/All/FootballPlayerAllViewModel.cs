﻿namespace StrumskaSlava.Web.ViewModels.FootballPlayer.All
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Services.Data;
    using StrumskaSlava.Services.Mapping;

    public class FootballPlayerAllViewModel : IMapFrom<FootballPlayerServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PlayerPositionName { get; set; }

        public string Picture { get; set; }
    }
}
