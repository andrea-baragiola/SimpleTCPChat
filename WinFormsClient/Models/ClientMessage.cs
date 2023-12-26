namespace WinFormsClient.Models
{
    public class ClientMessage
    {
        public string MessageSender { get; set; }
        public string MessageContent { get; set; }
        public int RoomId { get; set; }

        public ClientMessage(string messageSender, string messageContent, int roomId)
        {
            MessageSender = messageSender;
            MessageContent = messageContent;
            RoomId = roomId;
        }
    }
}
