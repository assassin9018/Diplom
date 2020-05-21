using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Должность работника
    /// </summary>
    internal class EmployeePosition : ITableRow
    {
        private const string Prefix = "Ep";
        private const string CId = Prefix + "Id";
        private const string CName = Prefix + "Name";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Name { get; }

        public EmployeePosition(string name)
        {
            Name = name;
        }

        public EmployeePosition(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            Name = reader.GetString(reader.GetOrdinal(CName));
        }

        public override string ToString() => Name;
    }
}
