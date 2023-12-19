namespace WebApiServer.Storage
{
    public interface IChatStorage
    {
        Dictionary<int, ChatRoom> ChatRoomDict { get; set; }

    }
}