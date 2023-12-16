using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace SimpleClient;

public class SimpleChatClient
{
    private TcpClient tcpClient;
    private StreamReader reader;
    private StreamWriter writer;

    public string Name { get; }
    public List<string> Messages { get; set; } = new();
    public string BaseUrl { get; }

    public SimpleChatClient(string name)
    {
        Name = name;
        BaseUrl = "https://localhost:7236/api/Chat";
        PopulateMessages();
    }

    public void SendMessage(string message) // manda messaggio al server con metodo POST
    {
        string requestBody = message;

        using (HttpClient client = new HttpClient())
        {
            StringContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync($"{BaseUrl}/post", content).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseData = response.Content.ReadAsStringAsync().Result;
            //}
        }
    }

    public void PopulateMessages() // get request to get all messages
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = client.GetAsync($"{BaseUrl}/all").Result;

            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                List<string>? messages = JsonSerializer.Deserialize<List<string>>(responseData);
                if (messages != null)
                {
                    Messages = messages;
                }
            }
        }
    }

    public void AddNewMessages()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = client.GetAsync($"{BaseUrl}/new").Result;

            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                List<string>? messages = JsonSerializer.Deserialize<List<string>>(responseData);
                if (messages != null)
                {
                    Messages.Concat(messages).ToList();
                }
            }
        }
    }
}