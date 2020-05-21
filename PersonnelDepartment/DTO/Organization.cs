using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация об организации
    /// </summary>
    internal class Organization : OrganizationBase
    {
        private const string CAddress = Prefix + "Address";

        /// <summary>
        /// Адрес организации
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Город
        /// </summary>
        public City City { get; }

        public Organization(SqlDataReader reader) : base(reader)
        {
            Address = reader.GetString(reader.GetOrdinal(CAddress));
            City = new City(reader);
        }

        public Organization(string name, string address, City city) : base(name)
        {
            Address = address;
            City = city;
        }
    }
}
