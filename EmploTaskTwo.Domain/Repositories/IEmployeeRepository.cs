using EmploTaskTwo.Domain.Entities;
using System.Linq;

namespace EmploTaskTwo.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetEmployees();
        IQueryable<Team> GetTeams();
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
