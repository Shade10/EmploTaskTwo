using DomainEntities = EmploTaskTwo.Domain.Entities;
using EFEntities = EmploTaskTwo.Infrastructure.Context;

namespace EmploTaskTwo.Infrastructure.Mappers
{
    public static class VacationMapper
    {
        public static DomainEntities.Vacation ToDomain(EFEntities.Vacation entity)
        {
            if (entity == null) return null;

            return new DomainEntities.Vacation
            {
                Id = entity.Id,
                DateSince = entity.DateSince,
                DateUntil = entity.DateUntil,
                NumberOfHours = entity.NumberOfHours,
                IsPartialVacation = entity.IsPartialVacation,
                EmployeeId = entity.EmployeeId
            };
        }

        public static EFEntities.Vacation ToEntity(DomainEntities.Vacation domain)
        {
            if (domain == null) return null;

            return new EFEntities.Vacation
            {
                Id = domain.Id,
                DateSince = domain.DateSince,
                DateUntil = domain.DateUntil,
                NumberOfHours = domain.NumberOfHours,
                IsPartialVacation = domain.IsPartialVacation,
                EmployeeId = domain.EmployeeId
            };
        }
    }
}
