namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация об образовании
    /// </summary>
    internal class Education
    {
        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Специальность
        /// </summary>
        public string Specialty { get; }
        /// <summary>
        /// Код специальности
        /// </summary>
        public long SpecialtyCode { get; }
        /// <summary>
        /// Образовательное учреждение
        /// </summary>
        public string InstituteName { get; }
        /// <summary>
        /// Короткое имя образовательного учреждения.
        /// </summary>
        public string ShortName { get; }
        /// <summary>
        /// Город в котором получено образование
        /// </summary>
        public string City { get; }
        /// <summary>
        /// Тип образовательного учреждения
        /// </summary>
        public EducationType EducationType { get; }
    }

    internal enum EducationType
    {
        Unknown = 0,
        School,
        College,
        Institute
    }
}
