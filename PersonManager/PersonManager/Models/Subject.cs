using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Models
{
    public class Subject
    {
        public int ClassID { get; set; }
        public TimeSpan StartTime  { get; set; }
        public TimeSpan EndTime  { get; set; }
        public string? Room { get; set; }
        public string? SubjectName { get; set; }
        public Teacher? TeacherOfSubject { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Subject subject &&
                   ClassID == subject.ClassID;
        }


    }
}
