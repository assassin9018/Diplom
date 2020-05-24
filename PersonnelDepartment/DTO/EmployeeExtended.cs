using PersonnelDepartment.Windows;
using System;
using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Полная информация о работнике
    /// </summary>
    internal class EmployeeExtended : Employee
    {
        #region Псевдонимы столбцов

        private const string CPassportSeria = Prefix + "PassportSeria";
        private const string CPassportNumber = Prefix + "PassportNumber";
        private const string CPassportDate = Prefix + "PassportDate";
        private const string CPaspWho = Prefix + "PaspWho";
        private const string CPassportCode = Prefix + "PassportCode";
        private const string CPlaceOfResidence = Prefix + "PlaceOfResidence";
        private const string CPlaceOfRegistration = Prefix + "PlaceOfRegistration";
        private const string CIsMarried = Prefix + "IsMarried";
        private const string CChildrenCount = Prefix + "ChildrenCount";
        private int id;
        private EmployeeWindow employeeWindow;

        #endregion

        #region Паспортные данные

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string PassportSeria { get; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public int PassportNumber { get; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public DateTime PassportDate { get; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string PaspWho { get; }

        /// <summary>
        /// Код подразделения паспорта
        /// </summary>
        public int PassportCode { get; }

        /// <summary>
        /// Город проживания
        /// </summary>
        public City CityOfResidence { get; set; }

        /// <summary>
        /// Место проживания
        /// </summary>
        public string PlaceOfResidence { get; }

        /// <summary>
        /// Город регистрации
        /// </summary>
        public City CityOfRegistration { get; set; }

        /// <summary>
        /// Место регистрации
        /// </summary>
        public string PlaceOfRegistration { get; }

        #endregion

        #region Дополнительная информация

        /// <summary>
        /// Женат/замужем 
        /// </summary>
        public bool IsMarried { get; }

        /// <summary>
        /// Количество детей
        /// </summary>
        public int ChildrenCount { get; }

        /// <summary>
        /// Образование
        /// </summary>
        public Education Education { get; set; }

        #endregion

        /// <summary>
        /// Не использовать
        /// </summary>
        private EmployeeExtended()
            : base(default, default, default, default, default, default, default)
        {
            throw new NotImplementedException();
        }

        public EmployeeExtended(SqlDataReader reader) : base(reader)
        {
            PassportSeria = reader.GetString(reader.GetOrdinal(CPassportSeria)).Trim();
            PassportNumber = reader.GetInt32(reader.GetOrdinal(CPassportNumber));
            PassportDate = reader.GetDateTime(reader.GetOrdinal(CPassportDate));
            PaspWho = reader.GetString(reader.GetOrdinal(CPaspWho)).Trim();
            PassportCode = reader.GetInt32(reader.GetOrdinal(CPassportCode));
            PlaceOfResidence = reader.GetString(reader.GetOrdinal(CPlaceOfResidence)).Trim();
            PlaceOfRegistration = reader.GetString(reader.GetOrdinal(CPlaceOfRegistration)).Trim();

            IsMarried = reader.GetBoolean(reader.GetOrdinal(CIsMarried));
            ChildrenCount = reader.GetInt32(reader.GetOrdinal(CChildrenCount));
        }

        public EmployeeExtended(EmployeeWindow employeeWindow) : base(employeeWindow)
        {
            PassportSeria = employeeWindow.EmPasSeria.Text.Trim();
            PassportNumber = int.Parse(employeeWindow.EmPasNumber.Text);
            PassportDate = employeeWindow.EmPassportDate.SelectedDate.Value;
            PaspWho = employeeWindow.EmPaspWho.Text.Trim();
            PassportCode = int.Parse(employeeWindow.EmPassportCode.Text);
            PlaceOfResidence = employeeWindow.EmPlaceOfResidence.Text.Trim();
            PlaceOfRegistration = employeeWindow.EmPlaceOfRegistration.Text.Trim();

            IsMarried = employeeWindow.EmIsMarried.IsChecked.Value;
            ChildrenCount = int.Parse(employeeWindow.EmChildren.Text);
            Education = employeeWindow.EmEducation.SelectedItem as Education;

            CityOfRegistration = employeeWindow.EmCityOfRegistration.SelectedItem as City;
            CityOfResidence = employeeWindow.EmCityOfResidence.SelectedItem as City;
        }

        public EmployeeExtended(int id, EmployeeWindow employeeWindow) : this(employeeWindow)
        {
            Id = id;
        }
    }
}
