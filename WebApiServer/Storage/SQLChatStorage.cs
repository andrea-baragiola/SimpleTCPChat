using Microsoft.Extensions.Configuration;
using WebApiServer.Models;
using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

    }
}
