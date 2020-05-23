using PersonnelDepartment.DTO;
using PersonnelDepartment.Helpers.Db;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PersonnelDepartment.Helpers
{
    internal class AutorizationHelper
    {
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for(int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if(0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Возращает пользователя при успешной авторизации, иначе выбрасывает <see cref="InvalidOperationException"/>
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Пользователь с переданной парой логин\пароль</returns
        public static User TryGetUser(string login, string password, out User user)
        {
            user = DbDirectReader.GetUserByLogin(login);

            //не проверяем на null, т.к. если пользователь не найден, то будет проброшено исключение
            using(MD5 md5Hash = MD5.Create())
                if(!VerifyMd5Hash(md5Hash, password, user.Password))
                    throw new InvalidOperationException(RuStrings.InvalidPassword);

            return user;
        }
    }
}
