﻿namespace StrumskaSlava.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StrumskaSlava.Services.Data;

    public interface IFootballPlayerService
    {
        Task<bool> CreatePlayer(FootballPlayerServiceModel footballPlayerServiceModel);

        Task<FootballPlayerServiceModel> GetById(string id);

        Task<bool> Edit(string id, FootballPlayerServiceModel footballPlayerServiceModel);

        Task<bool> Delete(string id);

        IQueryable<PlayerPositionServiceModel> GetAllPlayerPosition();

        IQueryable<FootballPlayerServiceModel> GetAllPlayers();
    }
}
