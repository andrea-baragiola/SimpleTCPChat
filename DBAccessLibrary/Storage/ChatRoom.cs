namespace DBAccessLibrary.Storage
{
    public class ChatRoom
    {
        public List<DBAMessage> AllMessages { get; set; }
        public int RoomId { get; set; }


        public ChatRoom()
        {
            AllMessages = new();
        }
    }
}