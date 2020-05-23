using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers;
using System.IO;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var frm = new PersonnelDepartmentWindow(new User("", "", null, Permissions.None));
            frm.ShowDialog();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConnectionStringBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
