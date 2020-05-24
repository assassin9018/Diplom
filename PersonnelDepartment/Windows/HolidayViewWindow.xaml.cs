using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            foreach(var trip in DbReader.ReadHolidays())
                HolidaysGrid.Items.Add(trip);
        }

        private void AddHoliday_Click(object sender, RoutedEventArgs e)
        {
            var frm = new HolidayWindow(_user);
            frm.ShowDialog();
            ReloadHolidays();
        }

        private void DelHoliday_Click(object sender, RoutedEventArgs e)
        {
            if(HolidaysGrid.SelectedItem is Holiday trip)
            {
                DbUpdater.RemoveHoliday(trip);
                ReloadHolidays();
            }
        }
    }
}
