using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Interfaces;
using EmploTaskTwo.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IQueryable<Employee> Query()
        {
            return _context.Employees
                .Select(e => EmployeeMapper.ToDomain(e))
                .AsQueryable();
        }

        public Employee GetById(int id)
        {
            return EmployeeMapper.ToDomain(_context.Employees.Find(id));
        }

        public void Add(Employee entity)
        {
            _context.Employees.Add(EmployeeMapper.ToEntity(entity));
            _context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            _context.Entry(EmployeeMapper.ToEntity(entity)).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var efEntity = _context.Employees.Find(id);
            if (efEntity != null)
            {
                _context.Employees.Remove(efEntity);
                _context.SaveChanges();
            }
        }

        public IList<Employee> GetEmployeesInTeamWithVacationInYear(string teamName, int year)
        {
            return _context.Employees
                .Where(e => e.Team.Name == teamName && e.Vacations.Any(v => v.DateSince.Year == year))
                .Select(e => EmployeeMapper.ToDomain(e))
                .ToList();
        }

        public IList<Employee> GetVacationDaysUsedByEmployeesForYear(int year, int hoursPerWorkDay)
        {
            return _context.Employees
                .Where(e => e.Vacations.Any(v => v.DateSince.Year == year && v.DateUntil < DateTime.Now))
                .Select(e => EmployeeMapper.ToDomain(e))
                .ToList();
        }
    }
}
