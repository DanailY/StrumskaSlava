﻿namespace StrumskaSlava.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using StrumskaSlava.Data.Common.Models;

    public class MatchStatus : BaseModel<string>
    {
        public string Name { get; set; }
    }
}
