using WebApiServer.Models;

namespace WebApiServer.Storage
{
    public class ChatRoom
    {
        public List<Message> AllMessages { get; set; }
        public int RoomId { get; set; }


        public ChatRoom()
        {
            AllMessages = new();
        }
    }
}