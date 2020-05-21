using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System.Windows;

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
            LoadData();
        }

        private void LoadData()
        {
            foreach(var item in DbReader.ReadBaseEmploees())
                UserName.Items.Add(item);
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
