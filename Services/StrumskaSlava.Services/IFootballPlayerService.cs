namespace StrumskaSlava.Services
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

        IQueryable<PlayerPositionServiceModel> GetAllPlayerPosition();
    }
}
