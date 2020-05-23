using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
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
        }

        internal EmployeeWindow(User user, EmployeeExtended employeeExtended) : this()
        {
            AddCityBtn1.IsEnabled = user.Permissions.HasFlag(Permissions.AddInnerInfo);
            AddCityBtn2.IsEnabled = user.Permissions.HasFlag(Permissions.AddInnerInfo);
            AddEducationBtn.IsEnabled = user.Permissions.HasFlag(Permissions.AddInnerInfo);
            AddPositionBtn.IsEnabled = user.Permissions.HasFlag(Permissions.AddInnerInfo);
            AddUnitBtn.IsEnabled = user.Permissions.HasFlag(Permissions.AddInnerInfo);
            //todo lock all buttons and show EmployeeData
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
            else
                MessageBox.Show(RuStrings.DataNotFilled);
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

            return false;
        }

        //todo тут должны быть проверки
        private bool IsAllOk() => true;

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
