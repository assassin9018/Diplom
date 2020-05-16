using PersonnelDepartment.Helpers;
using System;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация о работнике
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

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string PassportSeria { get; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string PassportNumber { get; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public string PassportDate { get; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string PaspWho { get; }

        /// <summary>
        /// Код подразделения паспорта
        /// </summary>
        public string PassportCode { get; }

        /// <summary>
        /// Место проживания
        /// </summary>
        public string PlaceOfResidence { get; }

        /// <summary>
        /// Место регистрации
        /// </summary>
        public string PlaceOfRegistration { get; }

        public override string ToString() => Utils.GetShortName(Surname, Name, Patronymic);
    }
}
