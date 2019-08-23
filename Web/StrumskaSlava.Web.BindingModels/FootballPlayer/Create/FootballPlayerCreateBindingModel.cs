using AutoMapper;
using Microsoft.AspNetCore.Http;
using StrumskaSlava.Services.Data;
using StrumskaSlava.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrumskaSlava.Web.BindingModels.FootballPlayer.Create
{
    public class FootballPlayerCreateBindingModel : IMapTo<FootballPlayerServiceModel>, IHaveCustomMappings
    {
        private const string AgeErrorMessage = "Годините на футболиста трябва да бъдата между {1} и {2}";
        private const string HeightErrorMessage = "Височината на футболиста трябва да бъдата между {1} и {2}";
        private const string PlayerNumberErrorMessage = "Номера на футболиста трябва да бъдата между {1} и {2}";

        private const int MinAgeOfPlayer = 15;
        private const int MaxAgeOfPlayer = 45;
        private const double MinHeightOfPlayer = 1.50;
        private const double MaxHeightOfPlayer = 2.20;
        private const int MinNumberOfPlayer = 1;
        private const int MaxNumberOfPlayer = 99;

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(MinAgeOfPlayer, MaxAgeOfPlayer, ErrorMessage = AgeErrorMessage)]
        public int Age { get; set; }

        [Required]
        [Range(MinHeightOfPlayer, MaxHeightOfPlayer, ErrorMessage = HeightErrorMessage)]
        public double Height { get; set; }


        [Required]
        public string PlayerPosition { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [Range(MinNumberOfPlayer, MaxNumberOfPlayer, ErrorMessage = PlayerNumberErrorMessage)]
        public int PlayerNumber { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<FootballPlayerCreateBindingModel, FootballPlayerServiceModel>()
                .ForMember(d => d.PlayerPosition, opts => opts.MapFrom(origin => new PlayerPositionServiceModel
                {
                    Name = origin.PlayerPosition
                }));
        }
    }
}
