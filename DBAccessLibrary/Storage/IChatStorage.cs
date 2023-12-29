namespace DBAccessLibrary.Storage
{
    public interface IChatStorage
    {
        void AddMessage(DBAMessage message);
        List<DBAMessage> GetRoomMessages(int roomId);
        void AddRoom();
        List<int> GetRoomsIds();

    }
}