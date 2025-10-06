using EmploTaskTwo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskTwo.Tests.TestHelpers
{
    public static class EmployeeMockData
    {
        public static IQueryable<Employee> GetEmployeesWithVacations(int year)
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Jan Kowalski",
                    Vacations = new List<Vacation>
                    {
                        new Vacation
                        {
                            Id = 1,
                            EmployeeId = 1,
                            DateSince = new DateTime(year, 5, 10),
                            DateUntil = new DateTime(year, 5, 14),
                            NumberOfHours = 40
                        }
                    }
                },
                new Employee
                {
                    Id = 2,
                    Name = "Kamil Nowak",
                    Vacations = new List<Vacation>
                    {
                        new Vacation
                        {
                            Id = 2,
                            EmployeeId = 2,
                            DateSince = new DateTime(year, 6, 1),
                            DateUntil = new DateTime(year, 6, 5),
                            NumberOfHours = 40
                        }
                    }
                }
            }.AsQueryable();
        }

        public static IQueryable<Employee> GetEmployeesWithoutVacations()
        {
            return new List<Employee>
            {
                new Employee { Id = 3, Name = "Anna Mariacka", Vacations = new List<Vacation>() },
                new Employee { Id = 4, Name = "Andrzej Abacki", Vacations = new List<Vacation>() }
            }.AsQueryable();
        }
    }
}
