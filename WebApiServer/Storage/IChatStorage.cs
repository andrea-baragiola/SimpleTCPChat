using WebApiServer.Models;

namespace WebApiServer.Storage
{
    public interface IChatStorage
    {
        void AddMessage(Message message);
        List<string> GetRoomMessages(int roomId);
    }
}