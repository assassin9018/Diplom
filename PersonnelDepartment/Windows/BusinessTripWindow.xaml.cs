using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для BusinessTripWindow.xaml
    /// </summary>
    public partial class BusinessTripWindow : Window
    {
        public BusinessTripWindow()
        {
            InitializeComponent();
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

        //todo тут должны быть проверки
        private bool IsAllOk() => true;

        private void AddOrganizationBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new OrganizationWindow();
            frm.ShowDialog();
        }
    }
}
