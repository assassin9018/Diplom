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
        /// Id города
        /// </summary>
        public int CityId { get; }
        /// <summary>
        /// Наименование города
        /// </summary>
        public string City { get; }
        /// <summary>
        /// Адрес организации
        /// </summary>
        public string Adress { get; }
    }
}
