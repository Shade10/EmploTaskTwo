using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Interfaces;
using EmploTaskTwo.Infrastructure.Mappers;
using System.Collections.Generic;
using System.Linq;
using EFEntities = EmploTaskTwo.Infrastructure.Context;

namespace EmploTaskTwo.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EFEntities.EmploTaskDBContext _context;

        public EmployeeRepository(EFEntities.EmploTaskDBContext context)
        {
            _context = context;
        }

        public void Add(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Employee> GetEmployeesInTeamWithVacationInYear(string teamName, int year)
        {
            throw new System.NotImplementedException();
        }

        public IList<Employee> GetVacationDaysUsedByEmployeesForYear(int year, int hoursPerWorkDay = 8)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Employee> Query()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
