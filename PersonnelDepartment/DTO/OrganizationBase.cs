using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    internal class OrganizationBase
    {
        protected const string Prefix = "Or";
        private const string CId = Prefix + "Id";
        private const string CName = Prefix + "Name";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        public string Name { get; }

        public OrganizationBase(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            Name = reader.GetString(reader.GetOrdinal(CName)).Trim();
        }

        public override string ToString() => Name;
    }
}
