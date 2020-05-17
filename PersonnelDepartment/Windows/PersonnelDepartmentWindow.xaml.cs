using PersonnelDepartment.DTO;
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

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWorkForm.xaml
    /// </summary>
    public partial class PersonnelDepartmentWindow : Window
    {
        public PersonnelDepartmentWindow()
        {
            InitializeComponent();
        }

        internal PersonnelDepartmentWindow(User user) : this()
        {
            var wu = new WorkingUnit(10, "Прогеры");
            var p = new EmployeePosition(25, "Джун");
            var em = new Employee(1,"Иванов", "Иван", "Иванович", p, wu, DateTime.MinValue);
            EmployeesGrid.Items.Add(em);
            wu = new WorkingUnit(10, "Тестеры");
            p = new EmployeePosition(25, "Мидл");
            em = new Employee(1, "Петров", "Пётр", "Петрович", p, wu, DateTime.MaxValue);
            EmployeesGrid.Items.Add(em);
        }

        private void ExtendedEmploee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddHoluday_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEmploee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelEmploee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTrip_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
