﻿namespace StrumskaSlava.Services.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ObjectMappingExtensions
    {
        public static T To<T>(this object origin)
        {
            if (origin == null)
            {
                throw new ArgumentNullException(nameof(origin));
            }

            return AutoMapper.Mapper.Map<T>(origin);
        }
    }
}
