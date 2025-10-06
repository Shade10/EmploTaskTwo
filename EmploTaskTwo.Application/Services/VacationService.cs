using EmploTaskTwo.Application.DTOs;
using EmploTaskTwo.Application.Interfaces;
using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Interfaces;
using EmploTaskTwo.Domain.Repositories;
using System.Collections.Generic;

namespace EmploTaskTwo.Application.Services
{
    public class VacationService : IVacationService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IVacationRepository _vacationRepository;

        public VacationService(
            IEmployeeRepository employeeRepository,
            ITeamRepository teamRepository,
            IVacationRepository vacationRepository)
        {
            _employeeRepository = employeeRepository;
            _teamRepository = teamRepository;
            _vacationRepository = vacationRepository;
        }

        public IEnumerable<Employee> GetEmployeesWithVacationInYear(string teamName, int year)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Team> GetTeamsWithNoVacationInYear(int year)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EmployeeVacationDaysDto> GetVacationDaysUsedCurrentYear()
        {
            throw new System.NotImplementedException();
        }
    }
}
