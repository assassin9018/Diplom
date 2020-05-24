using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для UsersViewWindow.xaml
    /// </summary>
    public partial class UsersViewWindow : Window
    {
        private readonly User _user;

        public UsersViewWindow()
        {
            InitializeComponent();
        }

        internal UsersViewWindow(User user) : this()
        {
            _user = user;
            ReloadUsers();
        }

        private void ReloadUsers()
        {
            UsersGrid.Items.Clear();
            foreach(var trip in DbReader.ReadUsers())
                UsersGrid.Items.Add(trip);
        }

        private void DelUser_Click(object sender, RoutedEventArgs e)
        {
            if(UsersGrid.SelectedItem is User user)
            {
                DbUpdater.RemoveUser(_user, user);
                ReloadUsers();
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var frm = new UserWindow();
            frm.ShowDialog();
            ReloadUsers();
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if(UsersGrid.SelectedItem is User user)
            {
                var frm = new UserWindow(user, false);
                frm.ShowDialog();
                ReloadUsers();
            }
        }

        private void ShowUser_Click(object sender, RoutedEventArgs e)
        {
            if(UsersGrid.SelectedItem is User user)
            {
                var frm = new UserWindow(user, true);
                frm.ShowDialog();
                ReloadUsers();
            }
        }
    }
}
