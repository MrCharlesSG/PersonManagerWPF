using PersonManager.Models;
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
    /// Interaction logic for ListPeoplePage.xaml
    /// </summary>
    public partial class ListPeoplePage : FramedPage
    {
        private static readonly Color NON_SELECTED_LIST_COLOR = (Color)ColorConverter.ConvertFromString("#64748b");
        private static readonly Color SELECTED_LIST_COLOR = (Color)ColorConverter.ConvertFromString("#F8FAFC");

        private static readonly int GENERAL_WIDTH_NOT_ALL = 550;
        private static readonly int GENERAL_WIDTH_ALL = 350;
        private static readonly int GENERAL_WIDTH_TEACHER = 440;
        private static readonly int COLUMN_WIDTH_ALL = 0;
        private static readonly int COLUMN_WIDTH_NOT_ALL = 90;


        private PersonViewModel.PERSON_TYPE selectedList;

        public ListPeoplePage(PersonViewModel personViewModel) : base(personViewModel)
        {
            InitializeComponent();
            lvPeople.ItemsSource = personViewModel.People;
            selectedList = PersonViewModel.PERSON_TYPE.ALL;
            ListBeenChanged();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditPersonPage(PersonViewModel!){
                Frame = Frame
            });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvPeople.SelectedItem != null)
            {
                Frame?.Navigate(new EditPersonPage(
                    PersonViewModel!,
                    lvPeople.SelectedItem as Person
                    )
                {
                    Frame=Frame
                });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvPeople.SelectedItem != null)
            {
                PersonViewModel!.People.Remove((lvPeople.SelectedItem as Person)!);
            }
        }

        private void Btn_All_Click(object sender, RoutedEventArgs e)
        {
            PersonViewModel!.UpdatePeopleList(PersonViewModel.PERSON_TYPE.ALL);
            selectedList = PersonViewModel.PERSON_TYPE.ALL;
            ListBeenChanged();
        }

        private void Btn_Employees_Click(object sender, RoutedEventArgs e)
        {
            PersonViewModel!.UpdatePeopleList(PersonViewModel.PERSON_TYPE.EMPLOYEE);
            selectedList = PersonViewModel.PERSON_TYPE.EMPLOYEE;
            ListBeenChanged();
        }

        private void Btn_Teachers_Click(object sender, RoutedEventArgs e)
        {
            PersonViewModel!.UpdatePeopleList(PersonViewModel.PERSON_TYPE.TEACHER);
            selectedList = PersonViewModel.PERSON_TYPE.TEACHER;
            ListBeenChanged();
        }

        private void Btn_Students_Click(object sender, RoutedEventArgs e)
        {
            PersonViewModel!.UpdatePeopleList(PersonViewModel.PERSON_TYPE.STUDENT);
            selectedList = PersonViewModel.PERSON_TYPE.STUDENT;
            ListBeenChanged();
        }

        private void ListBeenChanged()
        {
            Paint_Buttons();
            SetTable();
        }

        private void Paint_Buttons()
        {
            Brush seletedColor = new SolidColorBrush(SELECTED_LIST_COLOR);
            Brush nonSelectedColor = new SolidColorBrush(NON_SELECTED_LIST_COLOR);
            btn_All.Background=selectedList==PersonViewModel.PERSON_TYPE.ALL? seletedColor : nonSelectedColor;
            btn_Employees.Background=selectedList==PersonViewModel.PERSON_TYPE.EMPLOYEE? seletedColor : nonSelectedColor;
            btn_Students.Background=selectedList==PersonViewModel.PERSON_TYPE.STUDENT? seletedColor : nonSelectedColor;
            btn_Teachers.Background=selectedList==PersonViewModel.PERSON_TYPE.TEACHER? seletedColor : nonSelectedColor;

        }
        private void SetTable()
        {
            if (selectedList == PersonViewModel.PERSON_TYPE.ALL)
            {
                gvcAditional1.Width = COLUMN_WIDTH_ALL; 
                gvcAditional2.Width = COLUMN_WIDTH_ALL;
                lvPeople.Width = GENERAL_WIDTH_ALL;
            }
            else{
                gvcAditional1.Width = COLUMN_WIDTH_NOT_ALL;
                gvcAditional2.Width = COLUMN_WIDTH_NOT_ALL;
                lvPeople.Width=GENERAL_WIDTH_NOT_ALL;
                if(selectedList == PersonViewModel.PERSON_TYPE.STUDENT)
                {
                    gvcAditional1.Header = nameof(Student.Scholarship);
                    gvcAditional2.Header = nameof(Student.GPA);
                    gvcAditional1.DisplayMemberBinding = new System.Windows.Data.Binding(nameof(Student.Scholarship));
                    gvcAditional2.DisplayMemberBinding = new System.Windows.Data.Binding(nameof(Student.GPA));
                }
                else if(selectedList == PersonViewModel.PERSON_TYPE.TEACHER)
                {
                    lvPeople.Width = GENERAL_WIDTH_TEACHER;
                    gvcAditional1.Header = nameof(Teacher.Salary);
                    gvcAditional1.DisplayMemberBinding = new System.Windows.Data.Binding(nameof(Teacher.Salary));
                }
                else if(selectedList == PersonViewModel.PERSON_TYPE.EMPLOYEE)
                {
                    gvcAditional1.Header = nameof(Employee.Salary);
                    gvcAditional2.Header = "Work Hours";
                    gvcAditional1.DisplayMemberBinding = new System.Windows.Data.Binding(nameof(Employee.Salary));
                    gvcAditional2.DisplayMemberBinding = new System.Windows.Data.Binding("Work Hours");
                }
            }
            

        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvPeople.SelectedItem != null)
            {
               
                Frame?.Navigate(new ProfilePersonPage(
                    PersonViewModel,
                    (Person)lvPeople.SelectedItem
                    )
                {
                    Frame = Frame
                });
            }
        }

        private void BtnClassesView_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new ListClassPage(
                new ClassViewModel()
                )
            {
                Frame = Frame
            });
        }
    }
}
