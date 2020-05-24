using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для HolidayViewWindow.xaml
    /// </summary>
    public partial class HolidayViewWindow : Window
    {
        private readonly User _user;

        public HolidayViewWindow()
        {
            InitializeComponent();
        }

        internal HolidayViewWindow(User user) : this()
        {
            _user = user;
            ReloadHolidays();
        }

        private void ReloadHolidays()
        {
            HolidaysGrid.Items.Clear();
            foreach(var holiday in DbReader.ReadHolidays())
                HolidaysGrid.Items.Add(holiday);
        }

        private void AddHoliday_Click(object sender, RoutedEventArgs e)
        {
            var frm = new HolidayWindow(_user);
            frm.ShowDialog();
            ReloadHolidays();
        }

        private void DelHoliday_Click(object sender, RoutedEventArgs e)
        {
            if(HolidaysGrid.SelectedItem is Holiday holiday)
            {
                DbUpdater.RemoveHoliday(holiday);
                ReloadHolidays();
            }
        }
    }
}
