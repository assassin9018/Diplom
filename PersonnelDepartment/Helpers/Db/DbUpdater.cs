using PersonnelDepartment.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace PersonnelDepartment.Helpers.Db
{
    internal static class DbUpdater
    {
        public static void RemoveUser(User currentUser, User userForRemove)
        {
            if(currentUser.Id == userForRemove.Id)
                throw new InvalidOperationException(RuStrings.UsersAreSame);

            const string sqlExpression = "RemoveUser";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter("@Id", userForRemove.Id);
                command.Parameters.Add(nameParam);

                int stringsCount = command.ExecuteNonQuery();

                if(stringsCount > 0)
                    MessageBox.Show(RuStrings.UserDeleted);
                else
                    MessageBox.Show(RuStrings.RemoveNotExecuted);
            }
        }

        public static void RemoveEmployee(User currentUser, EmployeeBase employee)
        {
            if(currentUser.Employee.Id == employee.Id)
                throw new InvalidOperationException(RuStrings.UserEqualsEmploee);

            const string sqlExpression = "RemoveEmployee";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter("@Id", employee.Id);
                command.Parameters.Add(nameParam);

                int stringsCount = command.ExecuteNonQuery();

                if(stringsCount > 0)
                    MessageBox.Show(RuStrings.EmployeeDeleted);
                else
                    MessageBox.Show(RuStrings.RemoveNotExecuted);
            }
        }
    }
}
