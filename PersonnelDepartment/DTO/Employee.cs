using PersonnelDepartment.Windows;
using System;
using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Основная информация о работнике
    /// </summary>
    internal class Employee : EmployeeBase
    {
        private const string CBirthday = Prefix + "Birthday";

        /// <summary>
        /// Должность работника
        /// </summary>
        public EmployeePosition Position { get; }

        /// <summary>
        /// Подразделение в котором работает работник
        /// </summary>
        public WorkingUnit Unit { get; }

        /// <summary>
        /// Дата рождения работника
        /// </summary>
        public DateTime Birthday { get; }

        public string BirthdayDate => Birthday.ToLongDateString();

        public Employee(int id, string surname, string name, string patronymic, EmployeePosition position, WorkingUnit unit, DateTime birthday)
            : base(id, surname, name, patronymic)
        {
            Position = position;
            Unit = unit;
            Birthday = birthday;
        }

        public Employee(SqlDataReader reader) : base(reader)
        {
            Birthday = reader.GetDateTime(reader.GetOrdinal(CBirthday));
            Position = new EmployeePosition(reader);
            Unit = new WorkingUnit(reader);
        }

        public Employee(EmployeeWindow employeeWindow) : base(employeeWindow)
        {
            Position = employeeWindow.EmPosition.SelectedItem as EmployeePosition;
            Unit = employeeWindow.EmUnit.SelectedItem as WorkingUnit;
            Birthday = employeeWindow.EmBirthDay.SelectedDate.Value;
        }
    }
}
