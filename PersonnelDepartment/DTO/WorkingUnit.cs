using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Подразделение
    /// </summary>
    internal class WorkingUnit : ITableRow
    {
        private const string Prefix = "Wu";
        private const string CId = Prefix + "Id";
        private const string CName = Prefix + "Name";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Подразделение
        /// </summary>
        public string Name { get; }

        public WorkingUnit(string name)
        {
            Name = name;
        }

        public WorkingUnit(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            Name = reader.GetString(reader.GetOrdinal(CName));
        }

        public override string ToString() => Name;
    }
}
