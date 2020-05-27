using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWorkForm.xaml
    /// </summary>
    public partial class PersonnelDepartmentWindow : Window
    {
        private readonly User _user;
        private List<Employee> _employees;

        public PersonnelDepartmentWindow()
        {
            InitializeComponent();
        }

        internal PersonnelDepartmentWindow(User user) : this()
        {
            _user = user;
            LockForbiddenElements();
            ReloadEmployees();
        }

        private void LockForbiddenElements()
        {
            ExtendedEmploee.Visibility = _user.Permissions.HasFlag(Permissions.ReadExtendedEmInfo) ? Visibility.Visible : Visibility.Collapsed;
            UpdateEmploee.Visibility = _user.Permissions.HasFlag(Permissions.Recruitment) ? Visibility.Visible : Visibility.Collapsed;
            DelEmploee.Visibility = _user.Permissions.HasFlag(Permissions.Recruitment) ? Visibility.Visible : Visibility.Collapsed;
            AddTrip.Visibility = _user.Permissions.HasFlag(Permissions.BusinessTrip) ? Visibility.Visible : Visibility.Collapsed;
            AddHolyday.Visibility = _user.Permissions.HasFlag(Permissions.Holiday) ? Visibility.Visible : Visibility.Collapsed;
            AddEmploee.Visibility = _user.Permissions.HasFlag(Permissions.Recruitment) ? Visibility.Visible : Visibility.Collapsed;
            AddUser.Visibility = _user.Permissions.HasFlag(Permissions.Recruitment) ? Visibility.Visible : Visibility.Collapsed;
            ShowTrips.Visibility = _user.Permissions.HasFlag(Permissions.BusinessTrip) ? Visibility.Visible : Visibility.Collapsed;
            ShowHolidays.Visibility = _user.Permissions.HasFlag(Permissions.Holiday) ? Visibility.Visible : Visibility.Collapsed;
            ShowUsers.Visibility = _user.Permissions.HasFlag(Permissions.AddUsers) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ReloadEmployees()
        {
            EmployeesGrid.Items.Clear();
            _employees = new List<Employee>();
            int lastUnitId = (UnitFilter.SelectedItem as WorkingUnit)?.Id ?? 0;
            int lastPositionId = (PositionFilter.SelectedItem as EmployeePosition)?.Id ?? 0;
            foreach(var em in DbReader.ReadEmploees())
            {
                EmployeesGrid.Items.Add(em);
                _employees.Add(em);
            }
            UpdateFiltersData(lastUnitId, lastPositionId);
        }

        private void UpdateFiltersData(int lastUnitId, int lastPositionId)
        {
            var positionHash = new HashSet<EmployeePosition>();
            var unitHash = new HashSet<WorkingUnit>();
            foreach(var em in _employees)
            {
                positionHash.Add(em.Position);
                unitHash.Add(em.Unit);
            }
            UnitFilter.Items.Clear();
            UnitFilter.Items.Add("Все");
            unitHash.ToList().ForEach(x => UnitFilter.Items.Add(x));
            PositionFilter.Items.Clear();
            PositionFilter.Items.Add("Все");
            positionHash.ToList().ForEach(x => PositionFilter.Items.Add(x));

            int newUnitIndex, newPositionIndex;
            if(lastUnitId == 0)
                newUnitIndex = 0;
            else
                newUnitIndex = UnitFilter.Items.Cast<object>().TakeWhile(obj => obj is WorkingUnit u && u.Id != lastUnitId).Count();
            newUnitIndex = newUnitIndex == UnitFilter.Items.Count ? 0 : newUnitIndex;
            UnitFilter.SelectedIndex = newUnitIndex;

            if(lastPositionId == 0)
                newPositionIndex = 0;
            else
                newPositionIndex = PositionFilter.Items.Cast<object>().TakeWhile(obj => obj is EmployeePosition u && u.Id != lastPositionId).Count();
            newPositionIndex = newPositionIndex == PositionFilter.Items.Count ? 0 : newPositionIndex;
            PositionFilter.SelectedIndex = newPositionIndex;
        }

        private void ExtendedEmploee_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeesGrid.SelectedItem is Employee em)
            {
                var emExt = DbDirectReader.GetEmployee(em.Id);
                var frm = new EmployeeWindow(_user, emExt, true);
                frm.ShowDialog();
            }
        }

        private void AddHolyday_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeesGrid.SelectedItem is Employee em)
            {
                var frm = new HolidayWindow(_user, em);
                frm.ShowDialog();
            }
        }

        private void AddEmploee_Click(object sender, RoutedEventArgs e)
        {
            var frm = new EmployeeWindow(_user);
            frm.ShowDialog();
            ReloadEmployees();
        }

        private void DelEmploee_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeesGrid.SelectedItem is Employee employee)
                if(MessageBox.Show("Вы уверены, что хотите уволить сотрудника?", "Увольнение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DbUpdater.RemoveEmployee(_user, employee);
                    ReloadEmployees();
                }
        }

        private void AddTrip_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeesGrid.SelectedItem is Employee em)
            {
                var frm = new BusinessTripWindow(_user, em);
                frm.ShowDialog();
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var frm = new UserWindow();
            frm.Show();
        }

        private void ShowHolidays_Click(object sender, RoutedEventArgs e)
        {
            var frm = new HolidayViewWindow(_user);
            frm.ShowDialog();
        }

        private void ShowTrips_Click(object sender, RoutedEventArgs e)
        {
            var frm = new BusinessTripViewWindow(_user);
            frm.ShowDialog();
        }

        private void ShowUsers_Click(object sender, RoutedEventArgs e)
        {
            var frm = new UsersViewWindow(_user);
            frm.ShowDialog();
        }

        private void UpdateEmploee_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeesGrid.SelectedItem is Employee em)
            {
                var emExt = DbDirectReader.GetEmployee(em.Id);
                var frm = new EmployeeWindow(_user, emExt, false);
                frm.ShowDialog();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SearchRbt.IsChecked.Value)
                Search();
        }

        private void Filter_Changed(object sender, SelectionChangedEventArgs e)
            => SearchOrFilter();

        private void RbtChanged(object sender, RoutedEventArgs e)
            => SearchOrFilter();

        private void SearchOrFilter()
        {
            if(_employees == null)
                return;

            if(SearchRbt.IsChecked.Value)
                Search();
            else
                Filter();
        }

        private void Search()
        {
            if(_employees == null)
                return;

            EmployeesGrid.Items.Clear();
            string searchText = SearchBox.Text;
            foreach(var item in _employees.Where(em => em.Contains(searchText)))
                EmployeesGrid.Items.Add(item);
        }

        private void Filter()
        {
            if(_employees == null)
                return;

            EmployeesGrid.Items.Clear();
            var items = _employees.AsEnumerable();
            IEnumerable<Employee> afterPosFilter = items;
            if(PositionFilter.SelectedItem is EmployeePosition pos)
                afterPosFilter = items.Where(x => x.Position.Id == pos.Id);

            IEnumerable<Employee> afterUnitFilter = afterPosFilter;
            if(UnitFilter.SelectedItem is WorkingUnit unit)
                afterUnitFilter = items.Where(x => x.Unit.Id == unit.Id);

            foreach(var item in afterUnitFilter)
                EmployeesGrid.Items.Add(item);
        }

        private void Manual_Click(object sender, RoutedEventArgs e)
        {
            var frm = new UserManualWindow();
            frm.ShowDialog();
        }
    }
}
