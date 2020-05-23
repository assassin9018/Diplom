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

        internal HolydayWindow(User user) : this()
        {
            LoadData();
        }

        private void LoadData()
        {
            foreach(var item in DbReader.ReadBaseEmploees())
                EmployeeCb.Items.Add(item);
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
                bool isPaid = IsPaidCb.IsChecked.Value;
                DateTime start = StartDateDp.SelectedDate.Value;
                DateTime end = EndDateDp.SelectedDate.Value;
                var value = new Holiday(em, isPaid, start, end);

                DbWriter.AddHolyday(value);

                return true;
            }

            return false;
        }

        private bool IsAllOk() 
            => EmployeeCb.SelectedItem is EmployeeBase
            && IsPaidCb.IsChecked != null
            && StartDateDp.SelectedDate != null
            && EndDateDp.SelectedDate != null;

        private void AddOrganizationBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new OrganizationWindow();
            frm.ShowDialog();
        }
    }
}
