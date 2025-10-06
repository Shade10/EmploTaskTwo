using DomainEntities = EmploTaskTwo.Domain.Entities;
using EFEntities = EmploTaskTwo.Infrastructure.Context;


namespace EmploTaskTwo.Infrastructure.Mappers
{
    public static class VacationPackageMapper
    {
        public static DomainEntities.VacationPackage ToDomain(EFEntities.VacationPackage entity)
        {
            if (entity == null) return null;

            return new DomainEntities.VacationPackage
            {
                Id = entity.Id,
                Name = entity.Name,
                GrantedDays = entity.GrantedDays,
                Year = entity.Year
            };
        }

        public static EFEntities.VacationPackage ToEntity(DomainEntities.VacationPackage domain)
        {
            if (domain == null) return null;

            return new EFEntities.VacationPackage
            {
                Id = domain.Id,
                Name = domain.Name,
                GrantedDays = domain.GrantedDays,
                Year = domain.Year
            };
        }
    }
}
