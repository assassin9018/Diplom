using PersonnelDepartment.Helpers;

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
        public override string ToString() => Utils.GetShortName(Surname, Name, Patronymic);
    }
}
