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
    /// Lógica de interacción para ListClassPage.xaml
    /// </summary>
    public partial class ListClassPage : ClassFramedPage
    {
        private Person? Person;
        private readonly string clasesOfTitle = "({0})";

        public ListClassPage(ClassViewModel classViewModel, Person? person = null) : base(classViewModel)
        {
            InitializeComponent();
            this.Person = person;
            lvClasses.ItemsSource = classViewModel.Classes;
            if (person != null) InitializeWithPerson();
            else InitializeWithOutPerson();
            InitializeBackButton();
        }

        private void InitializeBackButton()
        {
            if(Person == null)
            {
                BtnBack.Background = Brushes.White;
                btniBack.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/student_icon4.png"));
            }
        }

        private void InitializeWithOutPerson()
        {
            lbClassesOfTitle.Content = "";
            ViewUtils.EnableButton(BtnAdd);
            ViewUtils.DisableButton(btnAdd_Existing);
        }

        private void InitializeWithPerson()
        {
            lbClassesOfTitle.Content = lbClassesOfTitle.Content = string.Format(clasesOfTitle, Person!.FirstName);
            if(Person is Student)
            {
                ViewUtils.EnableButton(btnAdd_Existing);
                ViewUtils.DisableButton(BtnAdd);
                btnDelete.Content = "Delete From Class";
                btnDelete.Background = Brushes.DeepSkyBlue;
            }
            else
            {
                ViewUtils.EnableButton(BtnAdd);
                ViewUtils.DisableButton(btnAdd_Existing);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if(Person != null)
            {
                Frame?.NavigationService.GoBack();
            }
            else
            {
                Frame?.Navigate(new ListPeoplePage(new PersonViewModel())
                {
                    Frame = Frame
                });
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvClasses.SelectedItem != null)
            {
                Frame?.Navigate(new ProfileClassPage(Person==null?ClassViewModel:null, (Subject)lvClasses.SelectedItem)
                {
                    Frame = Frame
                });
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditClassPage(ClassViewModel!)
            {
                Frame = Frame
            });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvClasses.SelectedItem != null)
            {
                Frame?.Navigate(new EditClassPage(ClassViewModel!, (Subject)lvClasses.SelectedItem )
                {
                    Frame = Frame
                });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvClasses.SelectedItem != null)
            {
                ClassViewModel!.Classes.Remove((Subject)lvClasses.SelectedItem);
            }
        }

        private void BtnAdd_Existing_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new StudentClassPage(ClassViewModel!, (Student)Person!)
            {
                Frame = Frame
            });
        }
    }
}
