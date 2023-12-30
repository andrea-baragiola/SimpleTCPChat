using WebApiServer.Models;

namespace WebApiServer.Storage
{
    public class ChatStorage : IChatStorage
    {

        public Dictionary<int, ChatRoom> ChatRoomDict { get; set; }
        public ChatStorage()
        {
            ChatRoomDict = new()
            {
                { 1, new ChatRoom() },   // default rooms
                { 2, new ChatRoom() }
            };

        }

        public void AddRoom()
        {
            ChatRoomDict.Add(ChatRoomDict.Count+1, new ChatRoom());
        }

        public void AddMessage(Message message)
        {
            ChatRoomDict[message.RoomId].AllMessages.Add(message);
        }

        public List<Message> GetRoomMessages(int roomId)
        {
            return ChatRoomDict[roomId].AllMessages;
        }

        public List<int> GetRoomsIds()
        {
            return ChatRoomDict.Keys.ToList();
        }


    }
}
