using DomainEntities = EmploTaskTwo.Domain.Entities;
using EFEntities = EmploTaskTwo.Infrastructure.Context;

namespace EmploTaskTwo.Infrastructure.Mappers
{
    public static class EmployeeMapper
    {
        public static DomainEntities.Employee ToDomain(EFEntities.Employee entity)
        {
            if (entity == null) return null;

            return new DomainEntities.Employee
            {
                Id = entity.Id,
                Name = entity.Name,
                TeamId = entity.TeamId,
                VacationPackageId = entity.VacationPackageId
            };
        }

        public static EFEntities.Employee ToEntity(DomainEntities.Employee domain)
        {
            if (domain == null) return null;

            return new EFEntities.Employee
            {
                Id = domain.Id,
                Name = domain.Name,
                TeamId = domain.TeamId,
                VacationPackageId = domain.VacationPackageId
            };
        }
    }
}
