using PersonManager.Models;
using PersonManager.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace PersonManager.Dal
{
    internal class SqlRepository : IRepository
    {
        private static readonly string cs =
            ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void AddPerson(Person person)
        {
            AddPersonAux(person);
            if( person.GetType() == typeof(Student) ) {
                AddStudent((Student)person);
            }else if( person.GetType() == typeof(Teacher))
            {
                AddTeacher((Teacher)person);
            }else if( person.GetType() == typeof(Employee))
            {
                AddEmployee((Employee)person);
            }
        }

        private void AddPersonAux(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "AddPerson";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
                {
                    Value = person.Picture
                });
            var id = new SqlParameter(nameof(Person.IDPerson), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            person.IDPerson = (int)id.Value;
            
        }

        private void AddStudent(Student student)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Student.Scholarship), student.Scholarship);
            cmd.Parameters.AddWithValue(nameof(Student.GPA), student.GPA);
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), student.IDPerson);
            var id = new SqlParameter(nameof(Student.StudentID), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            student.StudentID = (int)id.Value;
        }

        private void AddTeacher(Teacher teacher)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Teacher.Salary), teacher.Salary);
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), teacher.IDPerson);
            var id = new SqlParameter(nameof(Teacher.TeacherID), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            int result = (int)id.Value;
            if (result > -1) teacher.TeacherID = (int)result;
            else throw new Exception("Class Does Not Exist");
        }

        private void AddEmployee(Employee employee)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(employee.Salary), employee.Salary);
            cmd.Parameters.AddWithValue(nameof(employee.WorkHours), employee.WorkHours);
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), employee.IDPerson);
            var id = new SqlParameter(nameof(Employee.EmployeeID), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            employee.EmployeeID = (int)id.Value;
        }

        public void AddClass(Subject subject)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Subject.SubjectName), subject.SubjectName);
            cmd.Parameters.AddWithValue(nameof(Subject.EndTime), subject.EndTime);
            cmd.Parameters.AddWithValue(nameof(Subject.StartTime), subject.StartTime);
            cmd.Parameters.AddWithValue(nameof(Subject.Room), subject.Room);
            cmd.Parameters.AddWithValue(nameof(Teacher.TeacherID), subject.TeacherOfSubject!.TeacherID);
            var id = new SqlParameter(nameof(Subject.ClassID), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            subject.ClassID = (int)id.Value;
        }

        public void DeletePerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
            var id = new SqlParameter("Result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            if ((int)id.Value == -1)
            {
                throw new Exception("Teacher is teaching a class. First change the teacher of the class");
            }
        }

        public void DeleteClass(Subject subject)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Subject.ClassID), subject.ClassID);
            cmd.ExecuteNonQuery();
        }

        public IList<Person> GetPeople()
        {
            IList<Person> list = new List<Person>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(GetPeopleWithType(dr));
            }
            return list;
        }

        private Person GetPeopleWithType(SqlDataReader dr)
        {
            Person person = ReadPerson(dr);
            Student? student = GetStudentWithIDPerson(person.IDPerson, person);
            if(student != null) { return student; }
            Teacher? teacher = GetTeacherWithIDPerson(person.IDPerson, person);
            if(teacher!= null) { return teacher; }
            return GetEmployeeWithIDPerson(person.IDPerson, person)!;
        }

        public IList<Student> GetStudents()
        {
            IList<Student> list = new List<Student>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadStudent(dr, ReadPerson(dr)));
            }
            return list;
        }

        public IList<Employee> GetEmployees()
        {
            IList<Employee> list = new List<Employee>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadEmployee(dr, ReadPerson(dr)));
            }
            return list;
        }

        public IList<Teacher> GetTeachers()
        {
            IList<Teacher> list = new List<Teacher>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadTeacher(dr, ReadPerson(dr)));
            }
            return list;
        }

        public Person GetPerson(int idPerson)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), idPerson);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadPerson(dr);
            }
            throw new ArgumentException("Wrong id");
        }


        public Subject GetClass(int idSubject)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Subject.ClassID), idSubject);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadClass(dr);
            }
            throw new ArgumentException("Wrong id");
        }

        //HAcer que tenga la clase dinamica
        private Person ReadPerson(SqlDataReader dr)
            => new()
            {
                IDPerson = (int)dr[nameof(Person.IDPerson)],
                FirstName = dr[nameof(Person.FirstName)].ToString(),
                LastName = dr[nameof(Person.LastName)].ToString(),
                Age = (int)dr[nameof(Person.Age)],
                Email = dr[nameof(Person.Email)].ToString(),
                Picture = ImageUtils.ByteArrayFromReader(dr, nameof(Person.Picture))
            };

        private Subject ReadClass(SqlDataReader dr)
            => new()
            {
                ClassID = (int)dr[nameof(Subject.ClassID)],
                SubjectName = dr[nameof(Subject.SubjectName)].ToString(),
                Room = dr[nameof(Subject.Room)].ToString(),
                StartTime = (TimeSpan)dr[nameof(Subject.StartTime)],
                EndTime = (TimeSpan)dr[nameof(Subject.EndTime)],
                TeacherOfSubject = GetTeacher((int)dr[nameof(Teacher.TeacherID)]),
            };
        

        private Teacher GetTeacher(int teacherID)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue(nameof(Teacher.TeacherID), teacherID);
            using SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                return ReadTeacher(dr, ReadPerson(dr));
            }
            throw new ArgumentException("Wrong id");
        }

        private Student? GetStudentWithIDPerson(int iDPerson, Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), iDPerson);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadStudent(dr, person);
            }
            return null;
        }

        private Student ReadStudent(SqlDataReader dr, Person person)
            => new() { 
                IDPerson = person.IDPerson,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Age = person.Age,
                Picture = person.Picture,
                GPA = (decimal)dr[nameof(Student.GPA)],
                Scholarship = (decimal)dr[nameof(Student.Scholarship)],
                StudentID = (int)(dr[nameof(Student.StudentID)])
            };

        private Employee? GetEmployeeWithIDPerson(int iDPerson, Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), iDPerson);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadEmployee(dr, person);
            }
            return null;
        }

        private Employee ReadEmployee(SqlDataReader dr, Person person)
            => new() {
                IDPerson = person.IDPerson,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Age = person.Age,
                Picture = person.Picture,
                Salary = (decimal)dr[nameof(Employee.Salary)],
                WorkHours = (int)dr[nameof(Employee.WorkHours)],
                EmployeeID = (int)(dr[nameof(Employee.EmployeeID)])
            };
        

        private Teacher? GetTeacherWithIDPerson(int iDPerson, Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), iDPerson);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadTeacher(dr, person);
            }
            return null;
        }

        private Teacher ReadTeacher(SqlDataReader dr, Person person)
            => new()
            {
                IDPerson = person.IDPerson,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Age = person.Age,
                Picture = person.Picture,
                Salary = (decimal)dr[nameof(Teacher.Salary)],
                TeacherID = (int)(dr[nameof(Teacher.TeacherID)])
            };

        public void UpdatePerson(Person person)
        {
            UpdatePersonAux(person);
            if (person.GetType() == typeof(Student)) UpdateStudent((Student)person);            
            else if (person.GetType() == typeof(Teacher)) UpdateTeacher((Teacher)person);            
            else if (person.GetType() == typeof(Employee)) UpdateEmployee((Employee)person);
        }

        private void UpdatePersonAux(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UpdatePerson";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
                {
                    Value = person.Picture
                });
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
            cmd.ExecuteNonQuery();
        }

        private void UpdateStudent(Student student)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Student.StudentID), student.StudentID);
            cmd.Parameters.AddWithValue(nameof(Student.Scholarship), student.Scholarship);
            cmd.Parameters.AddWithValue(nameof(Student.GPA), student.GPA);
            cmd.ExecuteNonQuery();
        }

        private void UpdateTeacher(Teacher teacher)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Teacher.TeacherID), teacher.TeacherID);
            cmd.Parameters.AddWithValue(nameof(Teacher.Salary), teacher.Salary);
            cmd.ExecuteNonQuery();
        }

        private void UpdateEmployee(Employee employee)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(employee.EmployeeID), employee.EmployeeID);
            cmd.Parameters.AddWithValue(nameof(employee.Salary), employee.Salary);
            cmd.Parameters.AddWithValue(nameof(employee.WorkHours), employee.WorkHours);
            cmd.ExecuteNonQuery();
        }

        public void UpdateClass(Subject subject)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Subject.ClassID), subject.ClassID);
            cmd.Parameters.AddWithValue(nameof(Subject.SubjectName), subject.SubjectName);
            cmd.Parameters.AddWithValue(nameof(Subject.EndTime), subject.EndTime);
            cmd.Parameters.AddWithValue(nameof(Subject.StartTime), subject.StartTime);
            cmd.Parameters.AddWithValue(nameof(Subject.Room), subject.Room);
            cmd.Parameters.AddWithValue(nameof(Teacher.TeacherID), subject.TeacherOfSubject!.TeacherID);
            cmd.ExecuteNonQuery();
        }

        public IList<Subject> GetClassesOfStudent(int idStudent)
        {
            IList<Subject> list = new List<Subject>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Student.StudentID), idStudent);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadClass(dr));
            }
            return list;
        }

        public IList<Subject> GetClassesOfTeacher(int idTeacher)
        {
            IList<Subject> list = new List<Subject>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Teacher.TeacherID), idTeacher);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadClass(dr));
            }
            return list;
        }

        public IList<Student> GetStudentsByClass(int idClass)
        {
            IList<Student> list = new List<Student>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Subject.ClassID), idClass);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadStudent(dr, ReadPerson(dr)));
            }
            return list;
        }

        public IList<Subject> GetClasses()
        {
            IList<Subject> list = new List<Subject>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadClass(dr));
            }
            return list;
        }

        public void AddStudentToClass(int studentId, int classId)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Student.StudentID), studentId);
            cmd.Parameters.AddWithValue(nameof(Subject.ClassID), classId);
            cmd.Parameters.AddWithValue("Grade", 0);
            cmd.ExecuteNonQuery();
        }

        public void DeleteStudentClass(int studentId, int classId)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Subject.ClassID), classId);
            cmd.Parameters.AddWithValue(nameof(Student.StudentID), studentId);
            cmd.ExecuteNonQuery();
        }
    }
}
