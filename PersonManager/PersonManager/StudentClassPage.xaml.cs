using PersonManager.Dal;
using PersonManager.Models;
using PersonManager.Utils;
using PersonManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonManager
{
    /// <summary>
    /// Lógica de interacción para StudentClassPage.xaml
    /// </summary>
    public partial class StudentClassPage : ClassFramedPage
    {
        private Student? Student;
        private Subject? Subject;
        private PersonViewModel? PersonViewModel { get; }
        public StudentClassPage(ClassViewModel classViewModel, Student student) : base(classViewModel)
        {
            InitializeComponent();
            Student = student;
            InitializeTableSubject();
        }

        public StudentClassPage(PersonViewModel personViewModel, Subject subject) : base(new ClassViewModel())
        {
            InitializeComponent();
            PersonViewModel = personViewModel;
            Subject = subject;
            InitializeTableStudent();
        }

        private void InitializeTableStudent()
        {
            lvClasses.ItemsSource = RepositoryFactory.GetRepository().GetStudents();
            gvcFirst.Header = "First Name";
            gvcSecond.Header = "Last Name";
            gvcThird.Header = "Age";
            gvcFourth.Header = "Email";

            lbTitle.Content = "Add Student To " + Subject!.SubjectName!.ToUpper();

            gvcFirst.DisplayMemberBinding = new Binding(nameof(Student.FirstName));
            gvcSecond.DisplayMemberBinding = new Binding(nameof(Student.LastName));
            gvcThird.DisplayMemberBinding = new Binding(nameof(Student.Age));
            gvcFourth.DisplayMemberBinding = new Binding(nameof(Student.Email));
        }

        private void InitializeTableSubject()
        {
            lvClasses.ItemsSource = RepositoryFactory.GetRepository().GetClasses();
            gvcFirst.Header = "Subject Name";
            gvcSecond.Header = "Room";
            gvcThird.Header = "Start Time";
            gvcFourth.Header = "End Time";

            lbTitle.Content = "Add Class To " + Student!.FirstName!.ToUpper(); 

            gvcFirst.DisplayMemberBinding = new Binding(nameof(Subject.SubjectName));
            gvcSecond.DisplayMemberBinding = new Binding(nameof(Subject.Room));
            gvcThird.DisplayMemberBinding = new Binding(nameof(Subject.StartTime));
            gvcFourth.DisplayMemberBinding = new Binding(nameof(Subject.EndTime));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(Student!= null)
            {
                if(lvClasses.SelectedItem != null) {
                    Frame?.Navigate(new ProfileClassPage(null, (Subject)lvClasses.SelectedItem )
                    {
                        Frame = Frame
                    });
                }
            }
            else
            {
                if (lvClasses.SelectedItem != null)
                {
                    Frame?.Navigate(new ProfilePersonPage(null, (Student)lvClasses.SelectedItem)
                    {
                        Frame = Frame
                    });
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lvClasses.SelectedItem != null) {
                if(PersonViewModel != null)
                {
                    if (PersonViewModel.People.Contains((Person)lvClasses.SelectedItem))
                    {
                        ViewUtils.DisplayErrorMessage("The student is already in the class");
                    }
                    else { PersonViewModel.People.Add((Person)lvClasses.SelectedItem); }
                   
                }
                else
                {
                    if(ClassViewModel!.Classes.Contains((Subject)lvClasses.SelectedItem))
                        ViewUtils.DisplayErrorMessage("The student is already in the class");
                    else
                        ClassViewModel!.Classes.Add((Subject)lvClasses.SelectedItem);
                }
                Frame?.NavigationService.GoBack();
            }
        }
    }
}
