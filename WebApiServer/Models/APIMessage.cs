namespace WebApiServer.Models
{
    public class APIMessage
    {
        public string MessageSender { get; set; }
        public string MessageContent { get; set; }
        public int RoomId { get; set; }
    }
}
