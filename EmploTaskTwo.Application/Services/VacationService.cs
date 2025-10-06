using EmploTaskTwo.Application.DTOs;
using EmploTaskTwo.Application.Interfaces;
using EmploTaskTwo.Core.Constants;
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
            if (string.IsNullOrWhiteSpace(teamName))
            {
                throw new ArgumentException(ApplicationConstants.ErrorEmptyTeamName, nameof(teamName));
            }

            if (year < ApplicationConstants.MinYear)
            {
                throw new ArgumentException(ApplicationConstants.ErrorInvalidYear, nameof(year));
            }

            return _employeeRepository.GetEmployeesInTeamWithVacationInYear(teamName, year);
        }

        public IEnumerable<Team> GetTeamsWithNoVacationInYear(int year)
        {
            if (year < ApplicationConstants.MinYear)
            {
                throw new ArgumentException(ApplicationConstants.ErrorInvalidYear, nameof(year));
            }

            return _teamRepository.GetTeamsWithNoVacationInYear(year);
        }

        public IEnumerable<EmployeeVacationDaysDto> GetVacationDaysUsedCurrentYear()
        {
            var currentYear = DateTime.Now.Year;
            var employees = _employeeRepository.GetVacationDaysUsedByEmployeesForYear(currentYear);

            return employees.Select(e => new EmployeeVacationDaysDto
            {
                EmployeeId = e.Id,
                EmployeeName = e.Name,
                DaysUsed = CalculateVacationDays(e, currentYear),
                Year = currentYear
            }).ToList();
        }

        private double CalculateVacationDays(Employee employee, int year)
        {
            if (employee?.Vacations == null || !employee.Vacations.Any())
            {
                return default;
            }

            var hoursUsed = employee.Vacations
                .Where(v => v.DateSince.Year == year && v.DateUntil < DateTime.Now)
                .Sum(v => v.NumberOfHours);

            if(hoursUsed == default)
            {
                return default;
            }

            return hoursUsed / ApplicationConstants.HoursPerWorkDay;
        }
    }
}
