﻿using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Windows;

namespace PersonnelDepartment.Windows
{
    /// <summary>
    /// Логика взаимодействия для EducationWindow.xaml
    /// </summary>
    public partial class EducationWindow : Window
    {
        public EducationWindow()
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
                var specialty = SpecialtyCb.SelectedItem as Specialty;
                string instName = Institute.Text;
                var city = CityCb.SelectedItem as City;
                var eduType = EducationTypeCb.SelectedItem as EducationType;
                var value = new Education(specialty, instName, city, eduType);

                DbWriter.AddEducation(value);

                return true;
            }

            return false;
        }

        //todo тут должны быть проверки
        private bool IsAllOk() => true;

        private void AddCityBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new CityWindow();
            frm.ShowDialog();
        }

        private void AddEduTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new EducationTypeWindow();
            frm.ShowDialog();
        }

        private void AddSpecialtyBtn_Click(object sender, RoutedEventArgs e)
        {
            var frm = new SpecialtyWindow();
            frm.ShowDialog();
        }
    }
}
