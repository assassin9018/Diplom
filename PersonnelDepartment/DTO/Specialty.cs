using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    internal class Specialty : ITableRow
    {
        private const string Prefix = "Sp";
        private const string CId = Prefix + "Id";
        private const string CName = Prefix + "Name";
        private const string CCode = Prefix + "Code";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Название специальности
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Код специальности
        /// </summary>
        public long Code { get; }

        public Specialty(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            Name = reader.GetString(reader.GetOrdinal(CName)).Trim();
            Code = reader.GetInt64(reader.GetOrdinal(CCode));
        }

        public Specialty(int id, string name, long code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public Specialty(string name, long code)
        {
            Name = name;
            Code = code;
        }
    }
}
