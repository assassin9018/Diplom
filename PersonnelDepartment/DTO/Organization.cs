namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация об организации
    /// </summary>
    internal class Organization
    {
        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Город
        /// </summary>
        public City City { get; }

        /// <summary>
        /// Адрес организации
        /// </summary>
        public string Address { get; }
    }
}
