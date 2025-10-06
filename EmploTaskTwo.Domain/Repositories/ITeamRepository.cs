using EmploTaskTwo.Domain.Entities;
using System.Linq;

namespace EmploTaskTwo.Domain.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        IQueryable<Team> GetTeamsWithNoVacationInYear(int year);
    }
}
