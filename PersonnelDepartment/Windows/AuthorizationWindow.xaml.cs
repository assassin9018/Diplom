using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers;
using System;
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
            try
            {
                User user = AutorizationHelper.TryGetUser(Login.Text, Password.Password);
                Hide();
                var frm = new PersonnelDepartmentWindow(user);
                frm.ShowDialog();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConnectionStringBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new ConnStringEditorWindow();
            frm.ShowDialog();
        }
    }
}
