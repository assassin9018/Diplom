using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для EducationTypeWindow.xaml
    /// </summary>
    public partial class EducationTypeWindow : Window
    {
        public EducationTypeWindow()
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
                var value = new EducationType(EducationTypeTb.Text);

                DbWriter.AddEducationType(value);

                return true;
            }

            return false;
        }

        private bool IsAllOk() => EducationTypeTb.Text.Length > 0;
    }
}
