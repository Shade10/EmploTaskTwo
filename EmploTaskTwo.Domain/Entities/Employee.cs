using System.Collections.Generic;

namespace EmploTaskTwo.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public int VacationPackageId { get; set; }

        public virtual Team Team { get; set; }
        public virtual VacationPackage VacationPackage { get; set; }
        public virtual ICollection<Vacation> Vacations { get; set; }
    }
}
