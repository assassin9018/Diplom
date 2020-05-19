using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    public class EducationType
    {
        private const string Prefix = "Edt";
        private const string CId = Prefix + "Id";
        private const string CName = Prefix + "Name";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Тип образования
        /// </summary>
        public string Name { get; }

        public EducationType(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            Name = reader.GetString(reader.GetOrdinal(CName));
        }

        public override string ToString() => Name;
    }
}