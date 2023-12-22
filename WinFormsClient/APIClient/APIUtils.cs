namespace WinFormsClient.APIClient;

internal static class APIUtils
{
    public static async Task<HttpResponseMessage> GetRoomIdsAsync()
    {
        string getAllUrl = $"https://localhost:7236/api/Chat/rooms";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(getAllUrl);
            return response;
        }
    }

    internal static async Task<HttpResponseMessage> CreateRoomAsync()
    {
        string postUrl = "https://localhost:7236/api/Chat/createroom";
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.PostAsync(postUrl, null);
            return response;
        }
    }
}
