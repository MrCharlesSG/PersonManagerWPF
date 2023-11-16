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
using System.Xml.Linq;

namespace PersonManager
{
    /// <summary>
    /// Lógica de interacción para EditClassPage.xaml
    /// </summary>
    public partial class EditClassPage : ClassFramedPage
    {
        private readonly Subject Subject;
        private Teacher? selectedTeacher;
        public EditClassPage(ClassViewModel classViewModel, Subject? subject = null) : base(classViewModel)
        {
            InitializeComponent();
            InitializeInterface(subject);
            selectedTeacher = subject == null ? null : subject.TeacherOfSubject;
            Subject = subject ?? new Subject();
        }

        private void InitializeInterface(Subject? s)
        {
            lbSeleted_Teacher.Content = s == null ? "" : s.TeacherOfSubject!.FirstName + " " + s.TeacherOfSubject!.LastName;
            lvTeachers.ItemsSource = RepositoryFactory.GetRepository().GetTeachers();
            tbEndTime.Text = s == null ? "" : s.EndTime.ToString();
            tbStartTime.Text = s == null ? "" : s.StartTime.ToString();
            tbRoom.Text = s == null ? "" : s.Room;
            tbSubjectName.Text = s == null ? "" : s.SubjectName;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvTeachers.SelectedItem != null)
            {

                Frame?.Navigate(new ProfilePersonPage(
                    null,
                    (Teacher)lvTeachers.SelectedItem
                    )
                {
                    Frame = Frame
                });
            }
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidForm())
            {
                Subject.SubjectName = tbSubjectName.Text;
                Subject.Room = tbRoom.Text;
                Subject.StartTime = TimeSpan.Parse(tbStartTime.Text);   
                Subject.EndTime = TimeSpan.Parse(tbEndTime.Text);
                Subject.TeacherOfSubject = selectedTeacher;
                if (Subject.ClassID == 0)
                {
                    ClassViewModel!.Classes.Add(Subject);
                }
                else
                {
                    ClassViewModel!.Update(Subject);
                }
                OpenListClass();
            }
        }

        private void OpenListClass()
        {
            Frame?.Navigate(new ListClassPage(ClassViewModel!)
            {
                Frame = Frame
            });
        }

        private bool IsValidForm()
        {
            bool ok = true;
            grid.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                || "Time".Equals(e.Tag) && !TimeSpan.TryParse(e.Text, out _))
                {
                    e.Background = Brushes.LightCoral;
                    ok = false;
                }
                else
                    e.Background = Brushes.White;
            });
            if (selectedTeacher == null)
            {
                ok = false;
                btnSelectTeacher.Background = Brushes.LightCoral;
                lbSeleted_Teacher.Background = Brushes.LightCoral;
            }
            else
            {
                btnSelectTeacher.Background = Brushes.Transparent;
                lbSeleted_Teacher.Background = Brushes.Transparent;
            }
            return ok;
        }

        private void BtnSelectTeacher_Click(object sender, RoutedEventArgs e)
        {
            if (lvTeachers.SelectedItem != null)
            {
                selectedTeacher = lvTeachers.SelectedItem as Teacher;
                lbSeleted_Teacher.Content = selectedTeacher!.FirstName + " " + selectedTeacher.LastName;             
            }
        }
    }
}
