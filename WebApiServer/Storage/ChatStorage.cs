namespace WebApiServer.Storage
{
    public class ChatStorage : IChatStorage
    {

        public Dictionary<int, ChatRoom> ChatRoomDict { get; set; }
        public ChatStorage()
        {
            ChatRoomDict = new()
            {
                { 1, new ChatRoom() },
                { 2, new ChatRoom() }
            };

        }
    }
}
