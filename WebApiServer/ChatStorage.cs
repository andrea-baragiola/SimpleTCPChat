namespace WebApiServer
{
    public class ChatStorage : IChatStorage
    {
        public List<string> AllMessages { get; set; } = new();
        public List<string> NewMessages { get; set; } = new();
    }
}
