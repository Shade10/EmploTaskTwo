using EmploTaskTwo.Domain.Entities;
using System.Collections.Generic;

namespace EmploTaskTwo.Domain.Repositories
{
    public interface IVacationRepository : IRepository<Vacation>
    {
        IList<Vacation> GetVacationsForYear(int year);
    }
}
