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

            const string sqlExpression = "DeleteUser";

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

            const string sqlExpression = "DeleteEmployee";

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

        public static void UpdateEmployee(EmployeeExtended obj)
        {
            const string sqlExpression = "UpdateEmployee";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                //пиздец
                command.Parameters.Add(new SqlParameter("@EmId", obj.Id));
                command.Parameters.Add(new SqlParameter("@Birthday", obj.Birthday));
                command.Parameters.Add(new SqlParameter("@Name", obj.Name));
                command.Parameters.Add(new SqlParameter("@Surname", obj.Surname));
                command.Parameters.Add(new SqlParameter("@Patronymic", obj.Patronymic));
                command.Parameters.Add(new SqlParameter("@PositionId", obj.Position.Id));
                command.Parameters.Add(new SqlParameter("@WorkingUnitId", obj.Unit.Id));
                command.Parameters.Add(new SqlParameter("@CityIdOfRegistration", obj.CityOfRegistration.Id));
                command.Parameters.Add(new SqlParameter("@CityIdOfResidence", obj.CityOfResidence.Id));
                command.Parameters.Add(new SqlParameter("@EducationId", obj.Education.Id));
                command.Parameters.Add(new SqlParameter("@ChildrenCount", obj.ChildrenCount));
                command.Parameters.Add(new SqlParameter("@IsMarried", obj.IsMarried));
                command.Parameters.Add(new SqlParameter("@PaspWho", obj.PaspWho));
                command.Parameters.Add(new SqlParameter("@PassportCode", obj.PassportCode));
                command.Parameters.Add(new SqlParameter("@PassportDate", obj.PassportDate));
                command.Parameters.Add(new SqlParameter("@PassportNumber", obj.PassportNumber));
                command.Parameters.Add(new SqlParameter("@PassportSeria", obj.PassportSeria));
                command.Parameters.Add(new SqlParameter("@PlaceOfRegistration", obj.PlaceOfRegistration));
                command.Parameters.Add(new SqlParameter("@PlaceOfResidence", obj.PlaceOfResidence));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void UpdateUser(User obj)
        {
            const string sqlExpression = "UpdateUser";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UsId", obj.Id));
                command.Parameters.Add(new SqlParameter("@Login", obj.Login));
                command.Parameters.Add(new SqlParameter("@Password", obj.Password));
                command.Parameters.Add(new SqlParameter("@Permissions", obj.Permissions));
                command.Parameters.Add(new SqlParameter("@EmId", obj.Employee.Id));

                _ = command.ExecuteNonQuery();
            }
        }
    }
}
