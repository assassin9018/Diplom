using PersonnelDepartment.Helpers;
using System;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Основная информация о работнике
    /// </summary>
    internal class Employee
    {
        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Отчество(может быть null)
        /// </summary>
        public string Patronymic { get; }

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
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Position = position;
            Unit = unit;
            Birthday = birthday;
        }


        public override string ToString() => Utils.GetShortName(Surname, Name, Patronymic);
    }
}
