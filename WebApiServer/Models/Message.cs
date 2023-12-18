namespace WebApiServer.Models
{
    public class Message
    {
        public string MessageSender { get; set; }
        public string Content { get; set; }
        public int TargetRoomId { get; set; }
    }
}
