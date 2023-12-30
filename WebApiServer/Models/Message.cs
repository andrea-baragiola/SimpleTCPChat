namespace WebApiServer.Models
{
    public class Message
    {
        public string MessageSender { get; set; }
        public string MessageContent { get; set; }
        public int RoomId { get; set; }
    }
}
