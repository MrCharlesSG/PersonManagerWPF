using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Models
{
    public class Teacher:Person
    {
        public int TeacherID { get; set; }
        public decimal Salary { get; set; }

        public string GetFullName
        {
            get
            {
                try
                {
                    return FirstName + " " + LastName;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }
    }
}
