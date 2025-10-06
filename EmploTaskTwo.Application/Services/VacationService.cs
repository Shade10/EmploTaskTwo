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
        private readonly Func<DateTime> _currentDateProvider;

        public VacationService(
            IEmployeeRepository employeeRepository,
            ITeamRepository teamRepository,
            IVacationRepository vacationRepository,
            Func<DateTime> currentDateProvider = null)
        {
            _employeeRepository = employeeRepository;
            _teamRepository = teamRepository;
            _vacationRepository = vacationRepository;
            _currentDateProvider = currentDateProvider ?? (() => DateTime.Now);
        }

        public IEnumerable<Employee> GetEmployeesWithVacationInYear(string teamName, int year)
        {
            ValidateTeamName(teamName);
            ValidateYear(year);

            return _employeeRepository.GetEmployeesInTeamWithVacationInYear(teamName, year);
        }

        public IEnumerable<Team> GetTeamsWithNoVacationInYear(int year)
        {
            ValidateYear(year);

            return _teamRepository.GetTeamsWithNoVacationInYear(year);
        }

        public IEnumerable<EmployeeVacationDaysDto> GetEmployeesWithUsedVacationDaysCurrentYear()
        {
            var currentYear = _currentDateProvider().Year;
            var employees = _employeeRepository.GetVacationDaysUsedByEmployeesForYear(currentYear);

            return employees.Select(e => new EmployeeVacationDaysDto
            {
                EmployeeId = e.Id,
                EmployeeName = e.Name,
                DaysUsed = CalculateVacationDays(e, currentYear)
            }).ToList();
        }

        private double CalculateVacationDays(Employee employee, int year)
        {
            var vacations = _vacationRepository.GetEmployeeVacationsForYear(employee.Id, year);

            if (vacations == null || !vacations.Any())
            {
                return default;
            }

            var hoursUsed = vacations.Sum(v => v.NumberOfHours);

            if (hoursUsed == default)
            {
                return default;
            }

            return hoursUsed / ApplicationConstants.HoursPerWorkDay;
        }

        private void ValidateTeamName(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName))
            {
                throw new ArgumentException(ApplicationConstants.ErrorEmptyTeamName, nameof(teamName));
            }
        }

        private void ValidateYear(int year)
        {
            if (year < ApplicationConstants.MinYear)
            {
                throw new ArgumentException(ApplicationConstants.ErrorInvalidYear, nameof(year));
            }
        }
    }
}
