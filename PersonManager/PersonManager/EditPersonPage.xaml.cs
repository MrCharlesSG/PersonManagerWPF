using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonManager
{
    /// <summary>
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : FramedPage
    {
        private Person Person;
        private Person? OriginalPerson;
        private PersonViewModel.PERSON_TYPE type;
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        public EditPersonPage(PersonViewModel personViewModel,
            Person? person = null
            ) : base(personViewModel) 
        {
            InitializeComponent();
            Person = person ?? new Person();
            InitializeCommonInterface(person);
            InitializeSpecitalitation();
        }

        private void InitializeCommonInterface(Person? person)
        {
            tbAge.Text = Person == null ? "" : person!.Age.ToString();
            tbEmail.Text = Person == null ? "" : person!.Email;
            tbFirstName.Text = Person == null ? "" : person!.FirstName;
            tbLastName.Text = Person == null ? "" : person!.LastName;
            picture.Source = Person == null ? null : ImageUtils.ByteArrayToBitmapImage(person!.Picture!);
        }

        private void InitializeSpecitalitation()
        {
            if( Person != null )
            {
                DisableCheckBoxes();
                if(Person is Student )
                    SetStudentInterface((Student)Person);
                else if( Person is Teacher )
                    SetTeacherInterface((Teacher)Person);
                else
                    SetEmployeeInterface((Employee)Person);
            }
            else
            {
                cb_Student.IsChecked = true;
                Person = new Student();
            }
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormIsValid())
            {
                Person? newPerson = GetPerson();
                newPerson!.FirstName = tbFirstName.Text.Trim();
                newPerson!.IDPerson = Person!.IDPerson;
                newPerson!.LastName = tbLastName.Text.Trim();
                newPerson!.Age = int.Parse(tbAge.Text.Trim());
                newPerson!.Email = tbEmail.Text.Trim();
                newPerson!.Picture = ImageUtils.BitmapImageToByteArray((picture.Source as BitmapImage)!);
                if (newPerson.IDPerson == 0)
                {
                    PersonViewModel!.People.Add(newPerson);
                }
                else
                {
                    PersonViewModel!.UpdatePerson(newPerson);
                }
                OpenListPeople();
            }
        }

        private void OpenListPeople()
        {
            Frame?.Navigate(new ListPeoplePage(PersonViewModel!)
            {
                Frame = Frame
            });
        }

        private Person? GetPerson()
        {
            if(cb_Employee.IsChecked == true)
            {
                Employee employee = new()
                {
                    Salary = decimal.Parse(tb_Additional1.Text.Trim()),
                    WorkHours = int.Parse(tb_Additional2.Text.Trim())
                };
                return employee;
            } 
            else if(cb_Student.IsChecked == true)
            {
                Student student = new()
                {
                    GPA = decimal.Parse(tb_Additional1.Text.Trim()),
                    Scholarship = decimal.Parse(tb_Additional2.Text.Trim())
                };
                return student;
            }
            Teacher teacher = new()
            {
                Salary = decimal.Parse(tb_Additional1.Text.Trim()),
            };
            return teacher;
        }

        private bool FormIsValid()
        {
            bool ok = true;
            grid.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                || "Int".Equals(e.Tag) && !int.TryParse(e.Text, out int r)
                ||"Decimal".Equals(e.Tag) && !decimal.TryParse(e.Text, out decimal result)
                || "Email".Equals(e.Tag) && !ValidationUtils.IsValidEmail(e.Text)

                ){
                    e.Background = Brushes.LightCoral;
                    ok= false;
                }else
                    e.Background= Brushes.White;
            });

            if(picture.Source == null)
            {
                pictureBorder.BorderBrush = Brushes.LightCoral;
                ok = false;
            }else
                pictureBorder.BorderBrush = Brushes.White;

            return ok;
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var Dialog = new OpenFileDialog
            {
                Filter = Filter,
            };
            if (Dialog.ShowDialog()==true)
            {
                picture.Source=new BitmapImage(new Uri(Dialog.FileName));
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void Cb_Employee_Click(object sender, RoutedEventArgs e)
        {
            SetCheckBoxFalse();
            SetEmployeeInterface(null);
        }

        private void SetEmployeeInterface(Employee? employee)
        {
            cb_Employee.IsChecked = true;
            lb_Additional1.Content = "Salary";
            lb_Additional2.Content = "Working Hours";
            tb_Additional1.Tag = "Decimal";
            tb_Additional2.Tag = "Decimal";
            tb_Additional1.Text = employee == null ? "" : employee.Salary.ToString();
            tb_Additional2.Text = employee == null ? "" : employee.WorkHours.ToString();
            tb_Additional2.Visibility = Visibility.Visible;
        }

        private void Cb_Teacher_Click(object sender, RoutedEventArgs e)
        {
            SetCheckBoxFalse();
            SetTeacherInterface(null);
        }

        private void SetTeacherInterface(Teacher? teacher)
        {
            cb_Teacher.IsChecked = true;
            lb_Additional1.Content = "Salary";
            lb_Additional2.Content = "";
            tb_Additional1.Tag = "Decimal";
            tb_Additional2.Tag = "";
            tb_Additional1.Text = teacher == null ? "" : teacher.Salary.ToString();
            tb_Additional2.Text = "3";
            tb_Additional2.Visibility = Visibility.Hidden;
        }

        private void Cb_Student_Click(object sender, RoutedEventArgs e)
        {
            SetCheckBoxFalse();
            SetStudentInterface(null);
        }

        private void SetStudentInterface(Student? person)
        {
            cb_Student.IsChecked = true;
            lb_Additional1.Content = "GPA";
            lb_Additional2.Content = "Scholarship";
            tb_Additional1.Tag = "Decimal";
            tb_Additional2.Text = person == null ? "" : person.Scholarship.ToString();
            tb_Additional1.Text = person == null ? "" : person.GPA.ToString();
            tb_Additional2.Tag = "Decimal";
            tb_Additional2.Visibility = Visibility.Visible;
        }

        private void SetCheckBoxFalse()
        {
            cb_Employee.IsChecked = false;
            cb_Teacher.IsChecked = false;
            cb_Student.IsChecked = false;
        }

        private void DisableCheckBoxes()
        {
            cb_Teacher.IsEnabled = false;
            cb_Student.IsEnabled = false;
            cb_Employee.IsEnabled = false;
        }

    }
}
