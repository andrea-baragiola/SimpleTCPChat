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

    // Evento per gestire i messaggi ricevuti
    public event Action<string> MessageReceived;


    public void SendMessage(string message) // manda messaggio al server con metodo POST
    {
        string apiUrl = $"{BaseUrl}/post";
        string requestBody = message;

        using (HttpClient client = new HttpClient())
        {
            StringContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
    public void PopulateMessages()
    {
        string apiUrl = $"{BaseUrl}/all";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

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
        string apiUrl = $"{BaseUrl}/new";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

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

    //public void StartListening()
    //{
    //    // Loop per ricevere e gestire i messaggi dal server
    //    while (tcpClient.Connected)
    //    {
    //        string receivedMessage = reader.ReadLine();
    //        if (receivedMessage == null)
    //            break;

    //        OnMessageReceived(receivedMessage);
    //    }
    //}

    private void OnMessageReceived(string message)
    {
        // Richiama l'evento per gestire il messaggio ricevuto
        MessageReceived?.Invoke(message);
    }
}