namespace StrumskaSlava.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StrumskaSlava.Services.Data;

    public interface ILeagueTableService
    {
        IQueryable<LeagueTableServiceModel> GetAllTeams();

        Task<LeagueTableServiceModel> GetById(string id);

        Task<bool> Edit(string id, LeagueTableServiceModel leagueTableServiceModel);
    }
}
