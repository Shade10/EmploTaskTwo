using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Repositories;
using EmploTaskTwo.Infrastructure.Mappers;
using System.Data.Entity;
using System.Linq;
using EFEntities = EmploTaskTwo.Infrastructure.Context;

namespace EmploTaskTwo.Infrastructure.Repositories
{
    public class VacationPackageRepository : IVacationPackageRepository
    {
        private readonly EFEntities.EmploTaskDBContext _context;

        public VacationPackageRepository(EFEntities.EmploTaskDBContext context)
        {
            _context = context;
        }

        public IQueryable<VacationPackage> Query()
        {
            return _context.VacationPackages
                .AsNoTracking()
                .Select(v => VacationPackageMapper.ToDomain(v))
                .AsQueryable();
        }

        public VacationPackage GetById(int id)
        {
            return _context.VacationPackages
                .AsNoTracking()
                .Select(v => VacationPackageMapper.ToDomain(v))
                .Where(v => v.Id == id)
                .FirstOrDefault();
        }

        public void Add(VacationPackage entity)
        {
            _context.VacationPackages.Add(VacationPackageMapper.ToEntity(entity));
            _context.SaveChanges();
        }

        public void Update(VacationPackage entity)
        {
            _context.Entry(VacationPackageMapper.ToEntity(entity)).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.VacationPackages.Find(id);
            if (entity != null)
            {
                _context.VacationPackages.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
