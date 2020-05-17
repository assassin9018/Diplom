using System;
using System.Collections.Generic;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Полная информация о работнике
    /// </summary>
    internal class EmployeeExtended : Employee
    {
        public EmployeeExtended(int id, string surname, string name, string patronymic, EmployeePosition position, WorkingUnit unit, DateTime birthday) 
            : base(id, surname, name, patronymic, position, unit, birthday)
        {
        }

        #region Паспортные данные

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string PassportSeria { get; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public long PassportNumber { get; }

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
        public long PassportCode { get; }

        /// <summary>
        /// Место проживания
        /// </summary>
        public string PlaceOfResidence { get; }

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
        public Education Education { get; }

        #endregion
    }
}
