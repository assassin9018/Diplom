using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для Holyday.xaml
    /// </summary>
    public partial class HolydayWindow : Window
    {
        public HolydayWindow()
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
                bool isPaid = IsPaidCb.IsChecked.Value;
                DateTime start = StartDateDp.SelectedDate.Value;
                DateTime end = EndDateDp.SelectedDate.Value;
                var value = new Holiday(em, isPaid, start, end);

                DbWriter.AddHolyday(value);

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
