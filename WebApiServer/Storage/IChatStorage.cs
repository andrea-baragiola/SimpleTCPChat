using WebApiServer.Models;

namespace WebApiServer.Storage
{
    public interface IChatStorage
    {
        void AddMessage(Message message);
        List<Message> GetRoomMessages(int roomId);
        void AddRoom();
        List<int> GetRoomsIds();

        void CreateTables();
    }
}