using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    internal class City : ITableRow
    {
        private const string Prefix = "Ct";
        private const string CId = Prefix + "Id";
        private const string CName = Prefix + "Name";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Название города
        /// </summary>
        public string Name { get; }

        public City(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            Name = reader.GetString(reader.GetOrdinal(CName)).Trim();
        }

        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public City(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
