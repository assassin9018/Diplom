using PersonnelDepartment.DTO;
using System.Data;
using System.Data.SqlClient;

namespace PersonnelDepartment.Helpers.Db
{
    internal static class DbWriter
    {
        public static void AddBusinessTrip(BusinessTrip obj)
        {
            const string sqlExpression = "AddBusinessTrip";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OrId", obj.Organization.Id));
                command.Parameters.Add(new SqlParameter("@EmId", obj.Employee.Id));
                command.Parameters.Add(new SqlParameter("@BeginDate", obj.BeginDate));
                command.Parameters.Add(new SqlParameter("@EndDate", obj.EndDate));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void AddCity(City obj)
        {
            const string sqlExpression = "AddCity";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", obj.Name));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void AddEducation(Education obj)
        {
            const string sqlExpression = "AddEducation";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@InstituteName", obj.InstituteName));
                command.Parameters.Add(new SqlParameter("@SpId", obj.Specialty.Id));
                command.Parameters.Add(new SqlParameter("@EdtId", obj.EducationType.Id));
                command.Parameters.Add(new SqlParameter("@CtId", obj.City.Id));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void AddEducationType(EducationType obj)
        {
            const string sqlExpression = "AddEducationType";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", obj.Name));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void AddEmployee(EmployeeExtended obj)
        {
            const string sqlExpression = "AddEmployee";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                //пиздец
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

        public static void AddEmployeePosition(EmployeePosition obj)
        {
            const string sqlExpression = "AddEmployeePosition";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Position", obj.Name));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void AddHolyday(Holiday obj)
        {
            const string sqlExpression = "AddHoliday";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmId", obj.Employee.Id));
                command.Parameters.Add(new SqlParameter("@IsPaid", obj.IsPaid));
                command.Parameters.Add(new SqlParameter("@BeginDate", obj.BeginDate));
                command.Parameters.Add(new SqlParameter("@EndDate", obj.EndDate));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void AddOrganization(Organization obj)
        {
            const string sqlExpression = "AddOrganization";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", obj.Name));
                command.Parameters.Add(new SqlParameter("@CtId", obj.City.Id));
                command.Parameters.Add(new SqlParameter("@Address", obj.Address));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void AddSpecialty(Specialty obj)
        {
            const string sqlExpression = "AddSpecialty";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", obj.Name));
                command.Parameters.Add(new SqlParameter("@Code", obj.Code));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void AddUser(User obj)
        {
            const string sqlExpression = "AddUser";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Login", obj.Login));
                command.Parameters.Add(new SqlParameter("@Password", obj.Password));
                command.Parameters.Add(new SqlParameter("@Permissions", obj.Permissions));
                command.Parameters.Add(new SqlParameter("@EmId", obj.Employee.Id));

                _ = command.ExecuteNonQuery();
            }
        }

        public static void AddWorkingUnit(WorkingUnit obj)
        {
            const string sqlExpression = "AddWorkingUnit";

            using(SqlConnection connection = ConnectionFactory.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", obj.Name));

                _ = command.ExecuteNonQuery();
            }
        }
    }
}
