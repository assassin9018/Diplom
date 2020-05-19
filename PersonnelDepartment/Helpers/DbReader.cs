using PersonnelDepartment.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonnelDepartment.Helpers
{
    internal static class DbReader
    {
        public static IEnumerable<City> ReadCities()
        {
            using(var connection = ConnectionFactory.GetSqlConnection())
            {
                var command = new SqlCommand("CitiesView", connection);
                using(var reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                        while(reader.Read())
                            yield return new City(reader);
                }
            }
        }

        public static IEnumerable<EducationType> ReadEducationTypes()
        {
            using(var connection = ConnectionFactory.GetSqlConnection())
            {
                var command = new SqlCommand("EducationTypesView", connection);
                using(var reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                        while(reader.Read())
                            yield return new EducationType(reader);
                }
            }
        }

        public static IEnumerable<Organization> ReadOrganizations()
        {
            using(var connection = ConnectionFactory.GetSqlConnection())
            {
                var command = new SqlCommand("OrganizationsView", connection);
                using(var reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                        while(reader.Read())
                            yield return new Organization(reader);
                }
            }
        }

        public static IEnumerable<User> ReadUsers()
        {
            using(var connection = ConnectionFactory.GetSqlConnection())
            {
                var command = new SqlCommand("UsersView", connection);
                using(var reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                        while(reader.Read())
                            yield return new User(reader);
                }
            }
        }

        public static IEnumerable<WorkingUnit> ReadWorkingUnits()
        {
            using(var connection = ConnectionFactory.GetSqlConnection())
            {
                var command = new SqlCommand("WorkingUnitsView", connection);
                using(var reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                        while(reader.Read())
                            yield return new WorkingUnit(reader);
                }
            }
        }

        public static IEnumerable<Holyday> ReadHolydays()
        {
            using(var connection = ConnectionFactory.GetSqlConnection())
            {
                var command = new SqlCommand("HolydaysView", connection);
                using(var reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                        while(reader.Read())
                            yield return new Holyday(reader);
                }
            }
        }        
     public static IEnumerable<EmployeePosition> ReadEmployeePositions()
        {
            using(var connection = ConnectionFactory.GetSqlConnection())
            {
                var command = new SqlCommand("EmployeePositionView", connection);
                using(var reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                        while(reader.Read())
                            yield return new EmployeePosition(reader);
                }
            }
        }    
    }
}
