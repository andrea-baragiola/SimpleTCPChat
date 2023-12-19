using System.Text;
using System.Text.Json;
using WinFormsClient.Models;

namespace WinFormsClient.APIClient
{
    public class ChatAPIClient
    {
        public int RoomId { get; set; }

        public ChatAPIClient(int roomId)
        {
            RoomId = roomId;
        }

        // sends messages to the server with a post request (specifying sender name and chat room ID)
        internal async Task<HttpResponseMessage> SendAsync(string messageSender, string messageContent)
        {
            ClientMessage message = new(messageSender, messageContent, RoomId);

            string requestBody = JsonSerializer.Serialize(message);
            string postUrl = "https://localhost:7236/api/Chat/post";
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(postUrl, content);
                return response;
            }
        }

        // gets messages from the server with a get request for the specific room ID of the client
        public async Task<HttpResponseMessage> GetMessagesAsync()
        {
            string getAllUrl = $"https://localhost:7236/api/Chat/{RoomId}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(getAllUrl);
                return response;

                
            }

        }
    }
}
