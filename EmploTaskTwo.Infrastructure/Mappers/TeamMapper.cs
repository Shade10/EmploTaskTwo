using DomainEntities = EmploTaskTwo.Domain.Entities;
using EFEntities = EmploTaskTwo.Infrastructure.Context;

namespace EmploTaskTwo.Infrastructure.Mappers
{
    public static class TeamMapper
    {
        public static DomainEntities.Team ToDomain(EFEntities.Team entity)
        {
            if (entity == null) return null;

            return new DomainEntities.Team
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static EFEntities.Team ToEntity(DomainEntities.Team domain)
        {
            if (domain == null) return null;

            return new EFEntities.Team
            {
                Id = domain.Id,
                Name = domain.Name
            };
        }
    }
}
