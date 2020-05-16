namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Подразделение
    /// </summary>
    internal class WorkingUnit
    {
        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Подразделение
        /// </summary>
        public string Name { get; }

        public override string ToString() => Name;
    }
}
