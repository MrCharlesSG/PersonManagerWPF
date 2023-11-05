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
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        Person getPerson(int idPerson);
        IList<Person> GetPeople();
    }
}
