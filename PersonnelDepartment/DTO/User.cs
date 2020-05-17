namespace PersonnelDepartment.DTO
{
    /// <summary>
    /// Информация о пользователе
    /// </summary>
    internal class User
    {
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
        /// Id личной карточки
        /// </summary>
        public string EmployeeId { get; }
        /// <summary>
        /// Сокращенное имя пользователя.
        /// </summary>
        public string ShortName { get; }

        public Permissions Permissions { get; }
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
        AddUsers = 1 << 6
    }
}
