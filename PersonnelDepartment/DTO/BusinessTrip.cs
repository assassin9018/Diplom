using System;
using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация о командировке
    /// </summary>
    internal class BusinessTrip : ITableRow
    {
        private const string Prefix = "Bt";
        private const string CId = Prefix + "Id";
        private const string CBeginDate = Prefix + "BeginDate";
        private const string CEndDate = Prefix + "EndDate";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Базовая информация о работнике по его карточке
        /// </summary>
        public EmployeeBase Employee { get; }
        /// <summary>
        /// Информация об организации
        /// </summary>
        public OrganizationBase Organization { get; }
        /// <summary>
        /// Дата начала командировки
        /// </summary>
        public DateTime BeginDate { get; }
        public string BeginDateString => BeginDate.ToLongDateString();
        /// <summary>
        /// Дата окончания командировки
        /// </summary>
        public DateTime EndDate { get; }
        public string EndDateString => EndDate.ToLongDateString();

        public BusinessTrip(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            BeginDate = reader.GetDateTime(reader.GetOrdinal(CBeginDate));
            EndDate = reader.GetDateTime(reader.GetOrdinal(CEndDate));
            Employee = new EmployeeBase(reader);
            Organization = new OrganizationBase(reader);
        }

        public BusinessTrip(int id, EmployeeBase employee, OrganizationBase organization, DateTime beginDate, DateTime endDate)
        {
            Id = id;
            Employee = employee;
            Organization = organization;
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public BusinessTrip(EmployeeBase employee, OrganizationBase organization, DateTime beginDate, DateTime endDate)
        {
            Employee = employee;
            Organization = organization;
            BeginDate = beginDate;
            EndDate = endDate;
        }
    }
}
