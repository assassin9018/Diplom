using PersonnelDepartment.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PersonnelDepartment.Helpers.Db
{
    internal static class DbDirectReader
    {
        public static BusinessTrip GetBusinessTrip(int rowId)
        {
            const string sqlExpression = "BusinessTripById";
            BusinessTrip resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new BusinessTrip(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(BusinessTrip)));
            }

            return resultValue;
        }

        public static City GetCity(int rowId)
        {
            const string sqlExpression = "CityById";
            City resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new City(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(City)));
            }

            return resultValue;
        }

        public static Education GetEducation(int rowId)
        {
            const string sqlExpression = "EducationById";
            Education resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new Education(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(Education)));
            }

            return resultValue;
        }

        public static Employee GetEmployee(int rowId)
        {
            throw new NotImplementedException();
            const string sqlExpression = "EmployeeById";
            Employee resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new Employee(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(Employee)));
            }
            //нужно ещё пару запросов с выбором городов

            return resultValue;
        }

        public static EmployeePosition GetEmployeePosition(int rowId)
        {
            const string sqlExpression = "EmployeePositionById";
            EmployeePosition resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new EmployeePosition(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(EmployeePosition)));
            }

            return resultValue;
        }

        public static Holyday GetHolyday(int rowId)
        {
            const string sqlExpression = "HolydayById";
            Holyday resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new Holyday(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(Holyday)));
            }

            return resultValue;
        }

        public static Organization GetOrganization(int rowId)
        {
            const string sqlExpression = "OrganizationById";
            Organization resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new Organization(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(Organization)));
            }

            return resultValue;
        }

        public static Specialty GetSpecialty(int rowId)
        {
            const string sqlExpression = "SpecialtyById";
            Specialty resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new Specialty(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(Specialty)));
            }

            return resultValue;
        }

        public static User GetUser(int rowId)
        {
            const string sqlExpression = "UserById";
            User resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new User(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(User)));
            }

            return resultValue;
        }

        public static WorkingUnit GetWorkingUnit(int rowId)
        {
            const string sqlExpression = "UserById";
            WorkingUnit resultValue = null;

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода идентификатора
                SqlParameter nameParam = new SqlParameter("@RowId", rowId);
                // добавляем параметр
                command.Parameters.Add(nameParam);

                //если запись найдена, то читаем её и создаём запрошенный объект
                using(var reader = command.ExecuteReader())
                    if(reader.HasRows && reader.Read())
                        resultValue = new WorkingUnit(reader);
                    else
                        throw new InvalidOperationException(string.Format(RuStrings.RowNotFound, rowId, nameof(WorkingUnit)));
            }

            return resultValue;
        }
    }
}
