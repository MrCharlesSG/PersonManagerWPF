using PersonManager.Dal;
using PersonManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.ViewModels
{
    public class ClassViewModel
    {
        public ObservableCollection<Subject> Classes { get; }
        private Person? Person { get; set; }
        public ClassViewModel()
        {
            Classes = new ObservableCollection<Subject>(
                RepositoryFactory.GetRepository().GetClasses()
                );
            Classes.CollectionChanged += Classes_CollectionChanged;
        }

        public ClassViewModel(Person person)
        {
            if(person is Student)
            {
                Classes = new ObservableCollection<Subject>(
                    RepositoryFactory.GetRepository().GetClassesOfStudent(((Student)person).StudentID)
                    );
            }
            else
            {
                Classes = new ObservableCollection<Subject>(
                    RepositoryFactory.GetRepository().GetClassesOfTeacher(((Teacher)person).TeacherID)
                    );
            }
            Person = person;
            Classes.CollectionChanged += Classes_CollectionChanged;
        }

        private void Classes_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if(Person is Student) { RepositoryFactory.GetRepository().AddStudentToClass(((Student)Person).StudentID, Classes[e.NewStartingIndex].ClassID);}
                    else { RepositoryFactory.GetRepository().AddClass(Classes[e.NewStartingIndex]); }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if(Person is Student)
                        RepositoryFactory.GetRepository().DeleteStudentClass(((Student)Person).StudentID, e.OldItems!.OfType<Subject>().ToList()[0].ClassID);
                    else
                        RepositoryFactory.GetRepository().DeleteClass(
                        e.OldItems!.OfType<Subject>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateClass(
                       e.NewItems!.OfType<Subject>().ToList()[0]);
                    break;
            }
        }

        public void Update(Subject subject) => Classes[Classes.IndexOf(subject)] = subject;
    }
}
