using PersonManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Dal
{
    public interface IRepository
    {
        /*ADDs*/
        void AddPerson(Person person);
        void AddClass(Subject subject);

        void AddStudentToClass(int  studentId, int classId);

        /*UPDATES*/
        void UpdatePerson(Person person);
        void UpdateClass(Subject subject);

        /*DELETES*/
        void DeletePerson(Person person);
        void DeleteClass(Subject subject);

        void DeleteStudentClass(int studentId, int classId);
        
        /*GETTERS*/
        Person GetPerson(int idPerson);
        Subject GetClass(int idSubject);  
        IList<Person> GetPeople();
        IList<Student> GetStudents();
        IList<Employee> GetEmployees();
        IList<Teacher> GetTeachers();
        IList<Subject> GetClassesOfStudent(int idStudent);
        IList<Subject> GetClassesOfTeacher(int idTeacher);
        IList<Student> GetStudentsByClass(int idClass);
        IList<Subject> GetClasses();
    }
}
