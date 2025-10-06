using EmploTaskTwo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskTwo.Domain.Repositories
{
    public interface IVacationRepository : IRepository<Vacation>
    {
        IQueryable<Vacation> GetEmployeeVacationsForYear(int employeeId, int year);
    }
}
