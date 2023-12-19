namespace WebApiServer.Storage
{
    public class ChatRoom
    {
        public List<string> AllMessages { get; set; }
        public int RoomId { get; set; }


        public ChatRoom()
        {
            AllMessages = new();
        }
    }
}