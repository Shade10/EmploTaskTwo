using EmploTaskTwo.Application.DTOs;
using EmploTaskTwo.Application.Interfaces;
using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Interfaces;
using EmploTaskTwo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return _employeeRepository.GetEmployeesInTeamWithVacationInYear(teamName, year);
        }

        public IEnumerable<Team> GetTeamsWithNoVacationInYear(int year)
        {
            return _teamRepository.GetTeamsWithNoVacationInYear(year);
        }

        public IEnumerable<EmployeeVacationDaysDto> GetVacationDaysUsedCurrentYear()
        {
            var currentYear = DateTime.Now.Year;
            return _employeeRepository
                .GetVacationDaysUsedByEmployeesForYear(currentYear)
                .Select(e => new EmployeeVacationDaysDto
                {
                    EmployeeId = e.Id,
                    EmployeeName = e.Name,
                    DaysUsed = e.Vacations
                        .Where(v => v.DateSince.Year == currentYear && v.DateUntil < DateTime.Now)
                        .Sum(v => v.NumberOfHours) / ApplicationConstants.HoursPerWorkDay,
                    Year = currentYear
                }).ToList();
        }
    }
}
