﻿using System.Data.SqlClient;

namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация о пользователе
    /// </summary>
    internal class User : ITableRow
    {
        private const string Prefix = "Us";
        private const string CId = Prefix + "Id";
        private const string CLogin = Prefix + "Login";
        private const string CPassword = Prefix + "Password";
        private const string CPermissions = Prefix + "Permissions";
        /// <summary>
        /// Id записи в БД.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; }
        /// <summary>
        /// Базовая информация о пользователе из личной карточки
        /// </summary>
        public EmployeeBase Employee { get; }

        public Permissions Permissions { get; }

        public User(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal(CId));
            Login = reader.GetString(reader.GetOrdinal(CLogin)).Trim();
            Password = reader.GetString(reader.GetOrdinal(CPassword)).Trim();
            Permissions = (Permissions)reader.GetInt32(reader.GetOrdinal(CPermissions));
            Employee = new EmployeeBase(reader);
        }
    }

    public enum Permissions
    {
        None = 0,
        ReadExtendedEmInfo = 1,
        Recruitment = 1 << 1,
        Holyday = 1 << 2,
        BusinessTrip = 1 << 3,
        AddInnerInfo = 1 << 4,
        EditEmInfo = 1 << 5,
        AddUsers = 1 << 6,
        All = 0b111_1111
    }
}
