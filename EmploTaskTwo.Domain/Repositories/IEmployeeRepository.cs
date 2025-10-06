using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Repositories;
using System.Collections.Generic;

namespace EmploTaskTwo.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IList<Employee> GetEmployeesInTeamWithVacationInYear(string teamName, int year);
        IList<Employee> GetVacationDaysUsedByEmployeesForYear(int year, int hoursPerWorkDay = 8);
    }
}
