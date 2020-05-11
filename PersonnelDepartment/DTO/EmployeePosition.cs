namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Должность работника
    /// </summary>
    internal class EmployeePosition
    {
        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Position { get; }
    }
}
