using EmploTaskTwo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskTwo.Tests.Mocks
{
    public static class VacationMockData
    {
        public static IQueryable<Vacation> GetVacationsForYear(int year)
        {
            return new List<Vacation>
            {
                new Vacation
                {
                    Id = 1,
                    EmployeeId = 1,
                    DateSince = new DateTime(year, 5, 10),
                    DateUntil = new DateTime(year, 5, 14),
                    NumberOfHours = 40
                },
                new Vacation
                {
                    Id = 2,
                    EmployeeId = 2,
                    DateSince = new DateTime(year, 6, 1),
                    DateUntil = new DateTime(year, 6, 5),
                    NumberOfHours = 40
                }
            }.AsQueryable();
        }
    }
}
