using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System.Linq;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private readonly int _id;

        public EmployeeWindow()
        {
            InitializeComponent();
        }

        internal EmployeeWindow(User user) : this()
        {
            LoadInnerData();
            LockIfForbidden(user);
            _id = -1;
        }

        internal EmployeeWindow(User user, EmployeeExtended employeeExtended, bool @readonly) : this()
        {
            _id = employeeExtended.Id;
            LoadInnerData();
            LockIfForbidden(user);
            ShowEmloyeeData(employeeExtended, @readonly);
        }

        private void ShowEmloyeeData(EmployeeExtended em, bool @readonly)
        {
            EmName.Text = em.Name;
            EmName.IsReadOnly = @readonly;
            EmSurname.Text = em.Surname;
            EmSurname.IsReadOnly = @readonly;
            EmPatronymic.Text = em.Patronymic;
            EmPatronymic.IsReadOnly = @readonly;
            EmBirthDay.SelectedDate = em.Birthday;
            EmBirthDay.IsEnabled = !@readonly;
            EmChildren.Text = em.ChildrenCount.ToString();
            EmChildren.IsReadOnly = @readonly;
            EmIsMarried.IsChecked = em.IsMarried;
            EmIsMarried.IsEnabled = !@readonly;
            EmPaspWho.Text = em.PaspWho;
            EmPaspWho.IsReadOnly = @readonly;
            EmPassportCode.Text = em.PassportCode.ToString();
            EmPassportCode.IsReadOnly = @readonly;
            EmPassportDate.SelectedDate = em.PassportDate;
            EmPassportDate.IsEnabled = !@readonly;
            EmPasNumber.Text = em.PassportNumber.ToString();
            EmPasNumber.IsReadOnly = @readonly;
            EmPasSeria.Text = em.PassportSeria.ToString();
            EmPasSeria.IsReadOnly = @readonly;
            EmPlaceOfRegistration.Text = em.PlaceOfRegistration;
            EmPlaceOfRegistration.IsReadOnly = @readonly;
            EmPlaceOfResidence.Text = em.PlaceOfResidence;
            EmPlaceOfResidence.IsReadOnly = @readonly;

            int index = EmUnit.Items.Cast<WorkingUnit>().TakeWhile(un => un.Id != em.Unit.Id).Count();
            index = index == EmUnit.Items.Count ? -1 : index;
            EmUnit.SelectedIndex = index;
            EmUnit.IsEnabled = !@readonly;

            index = EmEducation.Items.Cast<Education>().TakeWhile(ed => ed.Id != em.Education.Id).Count();
            index = index == EmEducation.Items.Count ? -1 : index;
            EmEducation.SelectedIndex = index;
            EmEducation.IsEnabled = !@readonly;

            index = EmPosition.Items.Cast<EmployeePosition>().TakeWhile(ps => ps.Id != em.Position.Id).Count();
            index = index == EmPosition.Items.Count ? -1 : index;
            EmPosition.SelectedIndex = index;
            EmPosition.IsEnabled = !@readonly;

            index = EmCityOfRegistration.Items.Cast<City>().TakeWhile(ct => ct.Id != em.CityOfRegistration.Id).Count();
            index = index == EmCityOfRegistration.Items.Count ? -1 : index;
            EmCityOfRegistration.SelectedIndex = index;
            EmCityOfRegistration.IsEnabled = !@readonly;

            index = EmCityOfResidence.Items.Cast<City>().TakeWhile(ct => ct.Id != em.CityOfResidence.Id).Count();
            index = index == EmCityOfResidence.Items.Count ? -1 : index;
            EmCityOfResidence.SelectedIndex = index;
            EmCityOfResidence.IsEnabled = !@readonly;

            Enter.IsEnabled = !@readonly;
            Exit.IsEnabled = !@readonly;
        }

        private void LockIfForbidden(User user)
        {
            bool flag = user.Permissions.HasFlag(Permissions.AddInnerInfo);
            AddCityBtn1.IsEnabled = flag;
            AddCityBtn2.IsEnabled = flag;
            AddEducationBtn.IsEnabled = flag;
            AddPositionBtn.IsEnabled = flag;
            AddUnitBtn.IsEnabled = flag;
        }

        private void LoadInnerData()
        {
            ReloadCities();
            ReloadPositions();
            ReloadWorkingUnits();
            ReloadEducations();
        }

        private void ReloadEducations()
        {
            EmEducation.Items.Clear();
            foreach(var item in DbReader.ReadEducations())
                EmEducation.Items.Add(item);
        }

        private void ReloadWorkingUnits()
        {
            EmUnit.Items.Clear();
            foreach(var item in DbReader.ReadWorkingUnits())
                EmUnit.Items.Add(item);
        }

        private void ReloadPositions()
        {
            EmPosition.Items.Clear();
            foreach(var item in DbReader.ReadEmployeePositions())
                EmPosition.Items.Add(item);
        }

        private void ReloadCities()
        {
            EmCityOfRegistration.Items.Clear();
            EmCityOfResidence.Items.Clear();
            foreach(var item in DbReader.ReadCities())
            {
                EmCityOfRegistration.Items.Add(item);
                EmCityOfResidence.Items.Add(item);
            }
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
            ReloadCities();
        }

        private void AddPositionBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new PositionWindow();
            frm.ShowDialog();
            ReloadPositions();
        }

        private void AddUnitBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new WorkingUnitWindow();
            frm.ShowDialog();
            ReloadWorkingUnits();
        }

        private void AddEducationBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new EducationWindow();
            frm.ShowDialog();
            ReloadEducations();
        }
    }
}
