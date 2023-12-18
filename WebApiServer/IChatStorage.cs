namespace WebApiServer
{
    public interface IChatStorage
    {
        Dictionary<int, ChatRoom> ChatRoomDict { get; set; }

    }
}