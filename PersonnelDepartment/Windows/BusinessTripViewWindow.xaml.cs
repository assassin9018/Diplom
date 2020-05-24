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
    /// Логика взаимодействия для BusinessTripViewWindow.xaml
    /// </summary>
    public partial class BusinessTripViewWindow : Window
    {
        private readonly User _user;

        public BusinessTripViewWindow()
        {
            InitializeComponent();
        }

        internal BusinessTripViewWindow(User user) : this()
        {
            _user = user;
            ReloadTrips();
        }

        private void AddBusinessTrip_Click(object sender, RoutedEventArgs e)
        {
            var frm = new BusinessTripWindow(_user);
            frm.ShowDialog();
            ReloadTrips();
        }

        private void DelTrip_Click(object sender, RoutedEventArgs e)
        {
            if(TripsGrid.SelectedItem is BusinessTrip trip)
            {
                DbUpdater.RemoveBusinessTrip(trip);
                ReloadTrips();
            }
        }

        private void ReloadTrips()
        {
            TripsGrid.Items.Clear();
            foreach(var trip in DbReader.ReadBusinessTrips())
                TripsGrid.Items.Add(trip);
        }
    }
}
