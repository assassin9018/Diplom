using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для Organization.xaml
    /// </summary>
    public partial class OrganizationWindow : Window
    {
        public OrganizationWindow()
        {
            InitializeComponent();
        }

        internal OrganizationWindow(User user)
        {
            LoadData();
            AddCityBtn.IsEnabled = user.Permissions.HasFlag(Permissions.AddInnerInfo);
        }

        private void LoadData()
        {
            foreach(var item in DbReader.ReadCities())
                CityCb.Items.Add(item);
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if(TryWriteValue())
                Close();
            else
                MessageBox.Show(RuStrings.NotAllDataIsFilled);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        internal bool TryWriteValue()
        {
            if(IsAllOk())
            {

                string orgName = OrganizationNameTb.Text;
                string address = AddressTb.Text;
                var city = CityCb.SelectedItem as City;
                var value = new Organization(orgName, address, city);

                DbWriter.AddOrganization(value);

                return true;
            }

            return false;
        }

        private bool IsAllOk()
            => OrganizationNameTb.Text.Length > 0
            && AddressTb.Text.Length > 0
            && CityCb.SelectedItem is City;

        private void AddCityBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new CityWindow();
            frm.ShowDialog();
        }
    }
}
