using WebApiServer.Models;
using System.Data.SqlClient;
using Dapper;


namespace WebApiServer.Storage
{
    public class SQLChatStorage : IChatStorage
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public SQLChatStorage(IConfiguration configuration)
        {

            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("chatDb");
        }
        public List<int> GetRoomsIds()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ChatRoomsTable;";
                IEnumerable<int> roomIds = connection.Query<int>(query);
                return roomIds.ToList();
            }
        }

        public void AddRoom()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO ChatRoomsTable DEFAULT VALUES;";
                connection.Execute(insertQuery);
            }
        }


        public void AddMessage(Message message)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string insertQuery =
                    $"INSERT INTO MessagesTable (messageSender, messageContent, roomId)" +
                    $"VALUES ('{message.MessageSender}','{message.MessageContent}','{message.RoomId}');";
                connection.Execute(insertQuery);
            }
        }


        public List<Message> GetRoomMessages(int roomId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM MessagesTable WHERE roomId = {roomId};";
                IEnumerable<Message> messages = connection.Query<Message>(query);
                return messages.ToList();
            }
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
