using PersonManager.Dal;
using PersonManager.Models;
using PersonManager.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.ViewModels
{
    public class PersonViewModel
    {
        public enum PERSON_TYPE {ALL, STUDENT, TEACHER, EMPLOYEE};
        public ObservableCollection<Person> People { get; }

        private Subject? Subject { get; }
        public PersonViewModel()
        {
            People = new ObservableCollection<Person>(
                RepositoryFactory.GetRepository().GetPeople()
                );
            People.CollectionChanged += People_CollectionChanged;
        }

        public PersonViewModel(PERSON_TYPE type)
        {
            switch (type)
            {
                case PERSON_TYPE.STUDENT:
                    People = new ObservableCollection<Person>(
                RepositoryFactory.GetRepository().GetStudents()
                );
                    break;
                case PERSON_TYPE. TEACHER:
                    People = new ObservableCollection<Person>(
                        RepositoryFactory.GetRepository().GetTeachers());
                    break;
                default:
                    People = new ObservableCollection<Person>(
                        RepositoryFactory.GetRepository().GetPeople());
                    break;
            }
            People.CollectionChanged += People_CollectionChanged;
        }

        public PersonViewModel(Subject subject)
        {
            Subject = subject;
            People = new ObservableCollection<Person>(
                RepositoryFactory.GetRepository().GetStudentsByClass(Subject.ClassID)
                );
            People.CollectionChanged += People_CollectionChanged;
        }

        public void UpdatePeopleList(PERSON_TYPE personType)
        {
            People.CollectionChanged -= People_CollectionChanged;
            People.Clear();
            IEnumerable<Person>? peopleToAdd = null;
            switch (personType)
            {
                case PERSON_TYPE.ALL:
                    peopleToAdd = RepositoryFactory.GetRepository().GetPeople();
                    break;
                case PERSON_TYPE.STUDENT:
                    peopleToAdd = RepositoryFactory.GetRepository().GetStudents();
                    break;
                case PERSON_TYPE.TEACHER:
                    peopleToAdd = RepositoryFactory.GetRepository().GetTeachers();
                    break;
                case PERSON_TYPE.EMPLOYEE:
                    peopleToAdd = RepositoryFactory.GetRepository().GetEmployees();
                    break;
            }

            // Agregar personas a la colección
            if (peopleToAdd != null)
            {
                foreach (var person in peopleToAdd)
                {
                    People.Add(person);
                }
            }
            People.CollectionChanged += People_CollectionChanged; // Volver a conectar el manejador de eventos
        }


        private void People_CollectionChanged(object? sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if(Subject != null) { RepositoryFactory.GetRepository().AddStudentToClass(((Student)People[e.NewStartingIndex]).StudentID, Subject.ClassID);}
                    else{ RepositoryFactory.GetRepository().AddPerson(People[e.NewStartingIndex]);}
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (Subject == null)
                        try
                        {
                            RepositoryFactory.GetRepository().DeletePerson(
                                e.OldItems!.OfType<Person>().ToList()[0]);
                        }
                        catch(Exception ex)
                        {
                            ViewUtils.DisplayErrorMessage(ex.Message);
                            People.CollectionChanged -= People_CollectionChanged;
                            People.Add(e.OldItems!.OfType<Teacher>().ToList()[0]);
                            People.CollectionChanged += People_CollectionChanged;
                        }
                    else
                        RepositoryFactory.GetRepository().DeleteStudentClass(e.OldItems!.OfType<Student>().ToList()[0].StudentID, Subject.ClassID);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdatePerson(
                        e.NewItems!.OfType<Person>().ToList()[0]);
                    break;
            }
        }
        public void UpdatePerson(Person person) => People[People.IndexOf(person)] = person;
    }
}
