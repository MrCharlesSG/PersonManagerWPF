using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Models
{
    public class Student:Person
    {
        public int StudentID { get; set; }
        public decimal GPA { get; set; }
        public decimal Scholarship { get; set; }
    }
}
