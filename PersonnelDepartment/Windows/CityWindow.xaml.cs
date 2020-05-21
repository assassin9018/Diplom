using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для City.xaml
    /// </summary>
    public partial class CityWindow : Window
    {
        public CityWindow()
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
                var value = new City(CityNameTb.Text);

                DbWriter.AddCity(value);

                return true;
            }

            return false;
        }

        //todo тут должны быть проверки
        private bool IsAllOk() => true;
    }
}
