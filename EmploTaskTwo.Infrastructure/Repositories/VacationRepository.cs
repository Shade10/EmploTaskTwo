using EmploTaskTwo.Core.Constants;
using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Repositories;
using EmploTaskTwo.Infrastructure.Mappers;
using System;
using System.Data.Entity;
using System.Linq;
using EFEntities = EmploTaskTwo.Infrastructure.Context;

namespace EmploTaskTwo.Infrastructure.Repositories
{
    public class VacationRepository : IVacationRepository
    {
        private readonly EFEntities.EmploTaskDBContext _context;

        public VacationRepository(EFEntities.EmploTaskDBContext context)
        {
            _context = context;
        }

        public IQueryable<Vacation> Query()
        {
            return _context.Vacations
                .Select(v => VacationMapper.ToDomain(v))
                .AsQueryable();
        }

        public Vacation GetById(int id)
        {
            return VacationMapper.ToDomain(_context.Vacations.Find(id));
        }

        public void Add(Vacation entity)
        {
            _context.Vacations.Add(VacationMapper.ToEntity(entity));
            _context.SaveChanges();
        }

        public void Update(Vacation entity)
        {
            _context.Entry(VacationMapper.ToEntity(entity)).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Vacations.Find(id);
            if (entity != null)
            {
                _context.Vacations.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IQueryable<Vacation> GetVacationsForYear(int employeeId, int year)
        {
            if (year < ApplicationConstants.MinYear)
            {
                throw new ArgumentException(ApplicationConstants.ErrorInvalidYear, nameof(year));
            }

            return _context.Vacations
                .Where(v => v.EmployeeId == employeeId)
                .Where(v => v.DateSince.Year == year || v.DateUntil.Year == year)
                .Select(v => VacationMapper.ToDomain(v))
                .AsQueryable();
        }
    }
}
