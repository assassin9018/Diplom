using PersonnelDepartment.Helpers;
using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    internal class EmployeeBase : ITableRow
    {
        protected const string Prefix = "Em";
        private const string CId = Prefix + "Id";
        private const string CSurname = Prefix + "Surname";
        private const string CName = Prefix + "Name";
        private const string CPatronymic = Prefix + "Patronymic";

        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Отчество(может быть null)
        /// </summary>
        public string Patronymic { get; }

        public EmployeeBase(int id, string surname, string name, string patronymic)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }

        public EmployeeBase(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            Surname = reader.GetString(reader.GetOrdinal(CSurname)).Trim();
            Name = reader.GetString(reader.GetOrdinal(CName)).Trim();
            Patronymic = reader.GetString(reader.GetOrdinal(CPatronymic))?.Trim();
        }

        public override string ToString() => Utils.GetShortName(Surname, Name, Patronymic);
    }
}
