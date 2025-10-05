using System.Collections.Generic;

namespace EmploTaskTwo.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
