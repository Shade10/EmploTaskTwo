using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploTaskTwo.Application.DTOs
{
    public class EmployeeVacationDaysDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double DaysUsed { get; set; }
        public int Year { get; set; }
    }
}
