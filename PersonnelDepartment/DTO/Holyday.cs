using System;
using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация об отпуске
    /// </summary>
    internal class Holiday : ITableRow
    {
        private const string Prefix = "Hd";
        private const string CId = Prefix + "Id";
        private const string CBeginDate = Prefix + "BeginDate";
        private const string CEndDate = Prefix + "EndDate";
        private const string CIsPaid = Prefix + "IsPaid";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Базовая информация о работнике из личной карточки
        /// </summary>
        public EmployeeBase Employee { get; }
        /// <summary>
        /// Дата начала отпуска
        /// </summary>
        public DateTime BeginDate { get; }
        /// <summary>
        /// Дата окончания отпуска
        /// </summary>
        public DateTime EndDate { get; }
        /// <summary>
        /// Оплачивается ли отпуск
        /// </summary>
        public bool IsPaid { get; }

        public Holiday(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            BeginDate = reader.GetDateTime(reader.GetOrdinal(CBeginDate));
            EndDate = reader.GetDateTime(reader.GetOrdinal(CEndDate));
            IsPaid = reader.GetBoolean(reader.GetOrdinal(CIsPaid));
            Employee = new EmployeeBase(reader);
        }
    }
}
