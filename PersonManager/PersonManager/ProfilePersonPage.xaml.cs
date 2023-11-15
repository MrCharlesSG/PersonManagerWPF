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
    /// Lógica de interacción para ProfilePersonPage.xaml
    /// </summary>
    public partial class ProfilePersonPage : FramedPage
    {
        private readonly Person person;
        public ProfilePersonPage(PersonViewModel? personViewModel,
            Person person
            ) : base(personViewModel)
        {
            InitializeComponent();
            if(personViewModel == null )
            {
                ViewUtils.DisableButton(BtnEdit);
                ViewUtils.DisableButton(BtnDelete);
                ViewUtils.DisableButton(btnSubjects);
            }
            this.person = person;
            DataContext = person;
            InitLabels();
        }

        private void InitLabels()
        {
            if( person is Student )
            {
                lbAditional1.Content = ((Student)person).GPA;
                lbTitleAditional1.Content = "GPA:";
                lbAditional2.Content = ((Student)person).Scholarship;
                lbTitleAditional2.Content = "Scholarship:";
                lbTitle.Content = "Student";
                lbAditional2.Visibility = Visibility.Visible;
            }
            else if(person is Teacher )
            {
                lbAditional1.Content = ((Teacher)person).Salary;
                lbTitleAditional1.Content = "Salary:";
                lbTitleAditional2.Content = "";
                lbAditional2.Visibility = Visibility.Hidden;
                lbTitle.Content = "Teacher";
            }
            else
            {
                lbAditional1.Content = ((Employee)person).Salary;
                lbTitleAditional1.Content = "Salary:";
                lbAditional1.Content = ((Employee)person).WorkHours;
                lbTitleAditional1.Content = "Work hours:";
                lbTitle.Content = "Employee";
                lbAditional2.Visibility = Visibility.Visible;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditPersonPage(
                    PersonViewModel!,
                    person
                    )
            {
                Frame = Frame
            });

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonViewModel!.People.Remove(person);
            Frame?.NavigationService.GoBack();
        }

        private void BtnSubjects_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new ListClassPage(
                new ClassViewModel(person), person
                )
            {
                Frame = Frame
            });
        }
    }
}
