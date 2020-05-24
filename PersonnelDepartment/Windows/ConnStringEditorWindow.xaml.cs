using PersonnelDepartment.Helpers;
using System;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для ConnStringEditorWindow.xaml
    /// </summary>
    public partial class ConnStringEditorWindow : Window
    {
        public ConnStringEditorWindow()
        {
            InitializeComponent();
            ConnectionTb.Text = ConnectionFactory.GetConnectionString();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectionFactory.ChangeConnectionString(ConnectionTb.Text);
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
    }
}
