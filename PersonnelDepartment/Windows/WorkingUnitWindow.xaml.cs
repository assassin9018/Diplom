using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkingUnitWindow.xaml
    /// </summary>
    public partial class WorkingUnitWindow : Window
    {
        public WorkingUnitWindow()
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
                var value = new WorkingUnit(WorkingUnitTb.Text);

                DbWriter.AddWorkingUnit(value);

                return true;
            }

            return false;
        }

        private bool IsAllOk() => WorkingUnitTb.Text.Length > 0;
    }
}
