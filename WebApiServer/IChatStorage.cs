namespace WebApiServer
{
    public interface IChatStorage
    {
        List<string> AllMessages { get; set; }
        List<string> NewMessages { get; set; }
    }
}