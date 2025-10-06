using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Repositories;
using System.Linq;

namespace EmploTaskTwo.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesInTeamWithVacationInYear(string teamName, int year);
        IQueryable<Employee> GetVacationDaysUsedByEmployeesForYear(int year, int hoursPerWorkDay = 8);
    }
}
