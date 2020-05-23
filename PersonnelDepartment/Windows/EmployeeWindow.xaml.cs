using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
        }

        internal EmployeeWindow(User user) : this()
        {
            LoadData();
            LockIfForbidden(user);
        }

        internal EmployeeWindow(User user, EmployeeExtended employeeExtended) : this()
        {
            LockIfForbidden(user);
            ShowEmloyeeData(employeeExtended);
        }

        private void ShowEmloyeeData(EmployeeExtended employeeExtended) => throw new NotImplementedException();

        private void LockIfForbidden(User user)
        {
            bool flag = user.Permissions.HasFlag(Permissions.AddInnerInfo);
            AddCityBtn1.IsEnabled = flag;
            AddCityBtn2.IsEnabled = flag;
            AddEducationBtn.IsEnabled = flag;
            AddPositionBtn.IsEnabled = flag;
            AddUnitBtn.IsEnabled = flag;
        }

        private void LoadData()
        {
            foreach(var city in DbReader.ReadCities())
            {
                EmCityOfRegistration.Items.Add(city);
                EmCityOfResidence.Items.Add(city);
            }

            foreach(var city in DbReader.ReadEmployeePositions())
                EmPosition.Items.Add(city);

            foreach(var city in DbReader.ReadWorkingUnits())
                EmUnit.Items.Add(city);

            foreach(var city in DbReader.ReadEducations())
                EmEducation.Items.Add(city);
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if(TryWriteValue())
                Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        internal bool TryWriteValue()
        {
            if(IsAllOk())
            {
                var value = new EmployeeExtended(this);

                DbWriter.AddEmployee(value);

                return true;
            }
            else
                MessageBox.Show(RuStrings.NotAllDataIsFilled);

            return false;
        }

        private bool IsAllOk()
        {
            return EmName.Text.Length > 0
                   && EmSurname.Text.Length > 0
                   && EmPatronymic.Text.Length > 0
                   && EmBirthDay.SelectedDate != null
                   && EmPosition.SelectedItem is EmployeePosition
                   && EmUnit.SelectedItem is WorkingUnit
                   && EmPasSeria.Text.Length > 0
                   && int.TryParse(EmPasNumber.Text, out _)
                   && EmPassportDate.SelectedDate != null
                   && EmPaspWho.Text.Length > 0
                   && int.TryParse(EmPassportCode.Text, out _)
                   && EmCityOfResidence.SelectedItem is City
                   && EmCityOfRegistration.SelectedItem is City
                   && int.TryParse(EmChildren.Text, out _)
                   && EmEducation.SelectedItem is Education;
        }

        private void AddCityBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new CityWindow();
            frm.ShowDialog();
        }

        private void AddPositionBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new PositionWindow();
            frm.ShowDialog();
        }

        private void AddUnitBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new WorkingUnitWindow();
            frm.ShowDialog();
        }

        private void AddEducationBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new EducationWindow();
            frm.ShowDialog();
        }
    }
}
