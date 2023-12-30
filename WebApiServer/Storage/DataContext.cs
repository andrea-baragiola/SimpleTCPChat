using Dapper;
using System.Data.SqlClient;

namespace WebApiServer.Storage
{
    public class DataContext
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {

            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("chatDb");
        }

        public void CreateTables()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string insertQuery = @"
                    IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ChatRoomsTable')
                    BEGIN
                        CREATE TABLE ChatRoomsTable (
                            id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
                        );
	                    INSERT INTO ChatRoomsTable DEFAULT VALUES;
	                    INSERT INTO ChatRoomsTable DEFAULT VALUES;
                    END;

                    IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MessagesTable')
                    BEGIN
                        -- Create the table here
                        CREATE TABLE MessagesTable (
                            id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
		                    messageSender NVARCHAR(50),
		                    messageContent NVARCHAR(255),
		                    roomId INT NOT NULL
                        );
                    END;";
                connection.Execute(insertQuery);
            }
        }
    }
}
