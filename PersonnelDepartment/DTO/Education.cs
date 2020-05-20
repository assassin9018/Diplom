using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация об образовании
    /// </summary>
    internal class Education : ITableRow
    {
        private const string Prefix = "Ed";
        private const string CId = Prefix + "Id";
        private const string CInstituteName = Prefix + "InstituteName";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Специальность
        /// </summary>
        public Specialty Specialty { get; }
        /// <summary>
        /// Образовательное учреждение
        /// </summary>
        public string InstituteName { get; }
        /// <summary>
        /// Город в котором получено образование
        /// </summary>
        public City City { get; }
        /// <summary>
        /// Тип образовательного учреждения
        /// </summary>
        public EducationType EducationType { get; }

        public Education(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            InstituteName = reader.GetString(reader.GetOrdinal(CInstituteName)).Trim();
            Specialty = new Specialty(reader);
            City = new City(reader);
            EducationType = new EducationType(reader);
        }

        public Education(int id, Specialty specialty, string instituteName, City city, EducationType educationType)
        {
            Id = id;
            Specialty = specialty;
            InstituteName = instituteName;
            City = city;
            EducationType = educationType;
        }

        public Education(Specialty specialty, string instituteName, City city, EducationType educationType)
        {
            Specialty = specialty;
            InstituteName = instituteName;
            City = city;
            EducationType = educationType;
        }

        public override string ToString() => Specialty.ToString();
    }
}
