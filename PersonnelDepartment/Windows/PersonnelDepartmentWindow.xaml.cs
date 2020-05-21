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
            var wu = new WorkingUnit("Прогеры");
            var p = new EmployeePosition("Джун");
            var em = new Employee(1,"Иванов", "Иван", "Иванович", p, wu, DateTime.MinValue);
            EmployeesGrid.Items.Add(em);
            wu = new WorkingUnit("Тестеры");
            p = new EmployeePosition("Мидл");
            em = new Employee(1, "Петров", "Пётр", "Петрович", p, wu, DateTime.MaxValue);
            EmployeesGrid.Items.Add(em);
        }

        private void ExtendedEmploee_Click(object sender, RoutedEventArgs e)
        {
            var frm = new EmployeeWindow();
            frm.ShowDialog();
        }

        private void AddHolyday_Click(object sender, RoutedEventArgs e)
        {
            var frm = new HolydayWindow();
            frm.ShowDialog();
        }

        private void AddEmploee_Click(object sender, RoutedEventArgs e)
        {
            var frm = new EmployeeWindow();
            frm.ShowDialog();
        }

        private void DelEmploee_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ты уволен!!!!");
        }

        private void AddTrip_Click(object sender, RoutedEventArgs e)
        {
            var frm = new BusinessTripWindow();
            frm.ShowDialog();
        }
    }
}
