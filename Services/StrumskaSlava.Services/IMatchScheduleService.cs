namespace StrumskaSlava.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StrumskaSlava.Services.Data;

    public interface IMatchScheduleService
    {
        Task<bool> CreateMatchSchedule(MatchScheduleServiceModel matchScheduleServiceModel);

        IQueryable<MatchScheduleServiceModel> GetAll();

        Task<MatchScheduleServiceModel> GetById(string id);

        Task<bool> EditMatchSchedule(string id, MatchScheduleServiceModel matchScheduleServiceModel);

        Task<bool> Delete(string id);
    }
}
