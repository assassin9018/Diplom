namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Полная информация о работнике
    /// </summary>
    internal class EmployeeExtended : Employee
    {
        #region Паспортные данные

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
