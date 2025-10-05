using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Interfaces;
using System.Linq;
using dbContext = EmploTaskTwo.Infrastructure.Context;

namespace EmploTaskTwo.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly dbContext.EmploTaskDBContext _context;

        public EmployeeRepository(dbContext.EmploTaskDBContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Employee> GetEmployees()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Team> GetTeams()
        {
            throw new System.NotImplementedException();
        }
    }
}
