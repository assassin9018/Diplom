using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для PositionWindow.xaml
    /// </summary>
    public partial class PositionWindow : Window
    {
        public PositionWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if(TryWriteValue())
                Close();
            else
                MessageBox.Show(RuStrings.NotAllDataIsFilled);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        internal bool TryWriteValue()
        {
            if(IsAllOk())
            {
                var value = new EmployeePosition(PositionTb.Text);

                DbWriter.AddEmployeePosition(value);

                return true;
            }

            return false;
        }

        private bool IsAllOk() => PositionTb.Text.Length > 0;
    }
}
