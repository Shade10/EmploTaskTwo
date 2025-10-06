using EmploTaskTwo.Application.DTOs;
using EmploTaskTwo.Domain.Entities;
using System.Collections.Generic;

namespace EmploTaskTwo.Application.Interfaces
{
    public interface IVacationService
    {
        IEnumerable<Employee> GetEmployeesWithVacationInYear(string teamName, int year);
        IEnumerable<EmployeeVacationDaysDto> GetVacationDaysUsedCurrentYear();
        IEnumerable<Team> GetTeamsWithNoVacationInYear(int year);
    }
}
