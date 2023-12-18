namespace WinFormsClient.Models
{
    public class ClientMessage
    {
        public string MessageSender { get; set; }
        public string Content { get; set; }
        public int TargetRoomId { get; set; }
        public ClientMessage(string messageSender, string content, int targetRoomId)
        {
            MessageSender = messageSender;
            Content = content;
            TargetRoomId = targetRoomId;
        }
    }
}
