using System.Text;

namespace PersonnelDepartment.Helpers
{
    internal static class Utils
    {
        /// <summary>
        /// Возвращает сокращённое имя. (Иванов И.И.)
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="patronymic">Отчество. Может быть null</param>
        internal static string GetShortName(string surname, string name, string patronymic)
        {
            StringBuilder builder = new StringBuilder(surname);

            if(name.Length > 0 || !string.IsNullOrEmpty(patronymic))
                builder.Append(' ');

            if(name.Length > 0)
                builder.Append(name[0]).Append('.');

            if(!string.IsNullOrEmpty(patronymic))
                builder.Append(patronymic[0]).Append('.');

            return builder.ToString();
        }
    }
}
