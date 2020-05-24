using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Linq;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly User _user;

        public UserWindow()
        {
            InitializeComponent();
            LoadData();
        }

        internal UserWindow(User user, bool @readonly) : this()
        {
            _user = user;
            ShowData();
            if(@readonly)
                LockAllElements();
        }

        private void ShowData()
        {
            int index = UserName.Items.Cast<EmployeeBase>().TakeWhile(em => em.Id != _user.Employee.Id).Count();
            index = index == UserName.Items.Count ? -1 : index;
            UserName.SelectedIndex = index;

            Login.Text = _user.Login;
            ReadExtendedEmInfo.IsChecked = _user.Permissions.HasFlag(Permissions.ReadExtendedEmInfo);
            Recruitment.IsChecked = _user.Permissions.HasFlag(Permissions.Recruitment);
            Holiday.IsChecked = _user.Permissions.HasFlag(Permissions.Holiday);
            BusinessTrip.IsChecked = _user.Permissions.HasFlag(Permissions.BusinessTrip);
            AddInnerInfo.IsChecked = _user.Permissions.HasFlag(Permissions.AddInnerInfo);
            EditEmInfo.IsChecked = _user.Permissions.HasFlag(Permissions.EditEmInfo);
            AddUsers.IsChecked = _user.Permissions.HasFlag(Permissions.AddUsers);
        }

        private void LockAllElements()
        {
            UserName.IsEnabled = false;
            Login.IsReadOnly = true;
            Password.IsEnabled = false;
            PasswordConfirmation.IsEnabled = false;
            ReadExtendedEmInfo.IsEnabled = false;
            Recruitment.IsEnabled = false;
            Holiday.IsEnabled = false;
            BusinessTrip.IsEnabled = false;
            AddInnerInfo.IsEnabled = false;
            EditEmInfo.IsEnabled = false;
            AddUsers.IsEnabled = false;
        }

        private void LoadData()
        {
            foreach(var item in DbReader.ReadBaseEmploees())
                UserName.Items.Add(item);
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if(_user == null && TryWriteValue() || _user != null && TryUpdateValue())
                Close();
            else
                MessageBox.Show(RuStrings.NotAllDataIsFilled);
        }

        private bool TryUpdateValue()
        {
            if(IsAllOk())
            {
                string login = Login.Text;
                string password = Password.Password;
                var employee = UserName.SelectedItem as EmployeeBase;
                Permissions permissions = GetPermissions();

                var value = new User(_user.Id, login, password, employee, permissions);

                DbUpdater.UpdateUser(value);

                return true;
            }

            return false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool TryWriteValue()
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

            if(Holiday.IsChecked ?? false)
                perms |= Permissions.Holiday;

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

        private bool IsAllOk()
            => Login.Text.Length > 0
            && Password.Password.Length > 0
            && UserName.SelectedItem is EmployeeBase;
        //считаем, что все переключатели не могут быть null, т.е. ни разу с таким не сталкиваелся
    }
}
