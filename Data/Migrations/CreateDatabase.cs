using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;

 
namespace DevicesBE.Data.Migrations
{
    public static class Database
    {
        public static void CreateDatabase(string connectionString, string name)
        {
            var parameters =new DynamicParameters();
            parameters.Add("name", name);
            using var connection = new SqlConnection(connectionString);
            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name",
                 parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }
        
    }
}