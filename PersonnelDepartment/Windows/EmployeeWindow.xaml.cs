﻿using System;
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
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCityBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new CityWindow();
            frm.ShowDialog();
        }

        private void AddPositionBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new PositionWindow();
            frm.ShowDialog();
        }

        private void AddUnitBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new WorkingUnitWindow();
            frm.ShowDialog();
        }

        private void AddEducationBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new EducationWindow();
            frm.ShowDialog();
        }
    }
}
