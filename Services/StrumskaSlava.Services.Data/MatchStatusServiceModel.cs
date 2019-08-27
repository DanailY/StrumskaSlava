namespace StrumskaSlava.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Models;
    using StrumskaSlava.Services.Mapping;

    public class MatchStatusServiceModel : IMapFrom<MatchStatus>, IMapTo<MatchStatus>
    {
        public string Name { get; set; }
    }
}
