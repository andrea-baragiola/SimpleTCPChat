namespace WebApiServer
{
    public class ChatRoom
    {
        public List<string> AllMessages { get; set; }
        public int RoomId { get; set; }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public ChatRoom()
        {
            AllMessages = new();
        }
    }
}