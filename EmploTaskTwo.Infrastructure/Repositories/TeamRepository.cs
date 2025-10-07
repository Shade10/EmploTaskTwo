using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Repositories;
using EmploTaskTwo.Infrastructure.Mappers;
using System.Data.Entity;
using System.Linq;
using EFEntities = EmploTaskTwo.Infrastructure.Context;

namespace EmploTaskTwo.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly EFEntities.EmploTaskDBContext _context;

        public TeamRepository(EFEntities.EmploTaskDBContext context)
        {
            _context = context;
        }

        public IQueryable<Team> Query()
        {
            return _context.Teams
                .AsNoTracking()
                .Select(t => TeamMapper.ToDomain(t))
                .AsQueryable();
        }

        public Team GetById(int id)
        {
            return _context.Teams
                .AsNoTracking()
                .Select(t => TeamMapper.ToDomain(t))
                .Where(t => t.Id == id)
                .FirstOrDefault();
        }

        public void Add(Team team)
        {
            _context.Teams.Add(TeamMapper.ToEntity(team));
            _context.SaveChanges();
        }

        public void Update(Team team)
        {
            _context.Entry(TeamMapper.ToEntity(team)).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Teams.Find(id);
            if (entity != null)
            {
                _context.Teams.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IQueryable<Team> GetTeamsWithNoVacationInYear(int year)
        {
            return _context.Teams
                .AsNoTracking()
                .Where(t => !t.Employees
                    .Any(e => e.Vacations
                        .Any(v => v.DateSince.Year == year)))
                .Select(t => TeamMapper.ToDomain(t))
                .AsQueryable();
        }
    }
}
