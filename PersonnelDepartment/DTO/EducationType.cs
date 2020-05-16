namespace PersonnelDepartment.DTO
{
    public class EducationType
    {
        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Тип образования
        /// </summary>
        public string Name { get; }

        public override string ToString() => Name;
    }
}