using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWorkForm.xaml
    /// </summary>
    public partial class PersonnelDepartmentWindow : Window
    {
        private readonly User _user;

        public PersonnelDepartmentWindow()
        {
            InitializeComponent();
        }

        internal PersonnelDepartmentWindow(User user) : this()
        {
            _user = user;
            LockForbiddenElements();
            LoadEmployees();
        }

        private void LockForbiddenElements()
        {
            ExtendedEmploee.Visibility = _user.Permissions.HasFlag(Permissions.ReadExtendedEmInfo) ? Visibility.Visible : Visibility.Collapsed;
            DelEmploee.Visibility = _user.Permissions.HasFlag(Permissions.Recruitment) ? Visibility.Visible : Visibility.Collapsed;
            AddTrip.Visibility = _user.Permissions.HasFlag(Permissions.BusinessTrip) ? Visibility.Visible : Visibility.Collapsed;
            AddHolyday.Visibility = _user.Permissions.HasFlag(Permissions.Holyday) ? Visibility.Visible : Visibility.Collapsed;
            AddEmploee.Visibility = _user.Permissions.HasFlag(Permissions.Recruitment) ? Visibility.Visible : Visibility.Collapsed;
            AddUser.Visibility = _user.Permissions.HasFlag(Permissions.Recruitment) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void LoadEmployees()
        {
            EmployeesGrid.Items.Clear();
            foreach(var em in DbReader.ReadEmploees())
                EmployeesGrid.Items.Add(em);
        }

        private void ExtendedEmploee_Click(object sender, RoutedEventArgs e)
        {
            var frm = new EmployeeWindow(_user, null);
            frm.ShowDialog();
        }

        private void AddHolyday_Click(object sender, RoutedEventArgs e)
        {
            var frm = new HolydayWindow(_user);
            frm.ShowDialog();
        }

        private void AddEmploee_Click(object sender, RoutedEventArgs e)
        {
            var frm = new EmployeeWindow(_user);
            frm.ShowDialog();
            LoadEmployees();
        }

        private void DelEmploee_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ты уволен!!!!");
            LoadEmployees();
        }

        private void AddTrip_Click(object sender, RoutedEventArgs e)
        {
            var frm = new BusinessTripWindow(_user);
            frm.ShowDialog();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var frm = new UserWindow();
            frm.Show();
        }
    }
}
