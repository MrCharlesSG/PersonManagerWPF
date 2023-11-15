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
    /// Lógica de interacción para ProfileClassPage.xaml
    /// </summary>
    public partial class ProfileClassPage : ClassFramedPage
    {
        private Subject Subject { get; set; }   
        private PersonViewModel PersonViewModel { get; set; }
        public ProfileClassPage(ClassViewModel? classViewModel, Subject subject) : base(classViewModel)
        {
            InitializeComponent();
            Subject = subject;
            grid.DataContext = Subject;
            PersonViewModel = new PersonViewModel(subject);
            lbTeacherName.Content = Subject.TeacherOfSubject!.GetFullName;
            lvStudents.ItemsSource = PersonViewModel.People;
            if(classViewModel == null)
            {
                ViewUtils.DisableButton(BtnAddStudent);
                ViewUtils.DisableButton(BtnDelete);
                ViewUtils.DisableButton(BtnEdit);
                ViewUtils.DisableButton(btnDeleteStudent);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void BtnTeacher_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new ProfilePersonPage(null, Subject.TeacherOfSubject!)
            {
                Frame = Frame
            });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditClassPage(ClassViewModel!, Subject)
            {
                Frame = Frame
            }) ;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            ClassViewModel!.Classes.Remove(Subject);
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new StudentClassPage(PersonViewModel, Subject )
            {
                Frame = Frame
            });
        }

        private void ListViewItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if(lvStudents.SelectedItem != null)
            {
                Frame?.Navigate(new ProfilePersonPage(null, (Student)lvStudents.SelectedItem)
                {
                    Frame = Frame
                });
            }
        }

        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (lvStudents.SelectedItem != null)
            {
                PersonViewModel.People.Remove((Student)lvStudents.SelectedItem);
            }
        }
    }
}
