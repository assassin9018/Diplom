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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
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
                string login = Login.Text;
                string password = Password.Password;
                var employee = UserName.SelectedItem as EmployeeBase;
                Permissions permissions = GetPermissions();

                var value = new User(login, password, employee, permissions);

                DbWriter.AddUser(value);

                return true;
            }

            return false;
        }

        private Permissions GetPermissions()
        {
            var perms = Permissions.None;

            if(ReadExtendedEmInfo.IsChecked ?? false)
                perms |= Permissions.ReadExtendedEmInfo;

            if(Recruitment.IsChecked ?? false)
                perms |= Permissions.Recruitment;

            if(Holyday.IsChecked ?? false)
                perms |= Permissions.Holyday;

            if(BusinessTrip.IsChecked ?? false)
                perms |= Permissions.BusinessTrip;

            if(AddInnerInfo.IsChecked ?? false)
                perms |= Permissions.AddInnerInfo;

            if(AddUsers.IsChecked ?? false)
                perms |= Permissions.EditEmInfo;

            if(AddUsers.IsChecked ?? false)
                perms |= Permissions.AddUsers;

            return perms;
        }

        //todo тут должны быть проверки
        private bool IsAllOk() => true;
    }
}
