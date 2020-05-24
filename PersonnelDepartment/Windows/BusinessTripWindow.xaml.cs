using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Linq;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для BusinessTripWindow.xaml
    /// </summary>
    public partial class BusinessTripWindow : Window
    {

        internal BusinessTripWindow()
        {
            InitializeComponent();
        }

        internal BusinessTripWindow(User user) : this()
        {
            AddOrganizationBtn.IsEnabled = user.Permissions.HasFlag(Permissions.AddInnerInfo);
            LoadData();
        }

        internal BusinessTripWindow(User user, Employee employee) : this(user)
        {
            int index = EmployeeCb.Items.Cast<EmployeeBase>().TakeWhile(em => em.Id != employee.Id).Count();
            index = index == EmployeeCb.Items.Count ? -1 : index;
            EmployeeCb.SelectedIndex = index;
        }

        private void LoadData()
        {
            foreach(var item in DbReader.ReadBaseEmploees())
                EmployeeCb.Items.Add(item);

            ReloadData();
        }

        private void ReloadData()
        {
            OrganizationCb.Items.Clear();
            foreach(var item in DbReader.ReadBaseOrganizations())
                OrganizationCb.Items.Add(item);
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
                var em = EmployeeCb.SelectedItem as EmployeeBase;
                var org = OrganizationCb.SelectedItem as OrganizationBase;
                DateTime start = StartDateDp.SelectedDate.Value;
                DateTime end = EndDateDp.SelectedDate.Value;
                var value = new BusinessTrip(em, org, start, end);

                DbWriter.AddBusinessTrip(value);

                return true;
            }

            return false;
        }

        private bool IsAllOk()
        {
            DateTime? start = StartDateDp.SelectedDate.Value;
            DateTime? end = EndDateDp.SelectedDate.Value;

            return EmployeeCb.SelectedItem is EmployeeBase && OrganizationCb.SelectedItem is OrganizationBase && start != null && end != null;
        }

        private void AddOrganizationBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new OrganizationWindow();
            frm.ShowDialog();
            ReloadData();
        }
    }
}
