using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация об отпуске
    /// </summary>
    internal class Holyday
    {
        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Id записи работника в отпуске
        /// </summary>
        public int EmployeeId { get; }
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
    }
}
