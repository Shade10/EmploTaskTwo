using EmploTaskTwo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskTwo.Domain.Repositories
{
    public interface IVacationRepository : IRepository<Vacation>
    {
        IQueryable<Vacation> GetVacationsForYear(int year);
    }
}
