using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Models
{
    public class Employee:Person
    {
        public int EmployeeID { get; set; }
        public decimal Salary { get; set; }
        public int WorkHours { get; set; }
    }
}
