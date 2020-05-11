using System;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация о командировке
    /// </summary>
    internal class BusinessTrip
    {
        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Короткое имя работника
        /// </summary>
        public string Employee { get; }
        /// <summary>
        /// Наименование организации
        /// </summary>
        public string Organization { get; }
        /// <summary>
        /// Дата начала командировки
        /// </summary>
        public DateTime BeginDate { get; }
        /// <summary>
        /// Дата окончания командировки
        /// </summary>
        public DateTime EndDate { get; }
        /// <summary>
        /// Id организации
        /// </summary>
        public int OrganizationId { get; }
        /// <summary>
        /// Id записи работника в командировке
        /// </summary>
        public int EmployeeId { get; }
    }
}
