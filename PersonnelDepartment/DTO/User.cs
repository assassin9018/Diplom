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
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Id личной карточки
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// Сокращенное имя пользователя.
        /// </summary>
        public string ShortName { get; set; }
    }
}
