using EmploTaskTwo.Domain.Entities;
using System.Collections.Generic;

namespace EmploTaskTwo.Domain.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        IList<Team> GetTeamsWithNoVacationInYear(int year);
    }
}
