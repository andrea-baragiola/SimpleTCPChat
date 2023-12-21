﻿using WebApiServer.Models;

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

        public void AddMessage(Message message)
        {
            ChatRoomDict[message.TargetRoomId].AllMessages.Add($"{message.MessageSender} :  {message.Content}");
        }

        public List<string> GetRoomMessages(int roomId)
        {
            return ChatRoomDict[roomId].AllMessages;
        }
    }
}
