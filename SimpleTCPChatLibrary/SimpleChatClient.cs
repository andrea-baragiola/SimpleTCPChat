using System.Net.Sockets;

namespace SimpleTCPChatLibrary;

public class SimpleChatClient
{
    private TcpClient tcpClient;
    private StreamReader reader;
    private StreamWriter writer;

    // Evento per gestire i messaggi ricevuti
    public event Action<string> MessageReceived;

    public void Connect(string serverIp, int serverPort)
    {
        // Connessione al server
        tcpClient = new TcpClient(serverIp, serverPort);
        reader = new StreamReader(tcpClient.GetStream());
        writer = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true };

        // Leggi il messaggio di benvenuto
        string welcomeMessage = reader.ReadLine();
        OnMessageReceived(welcomeMessage);
    }

    public void SendMessage(string message)
    {
        // Invia il messaggio al server
        writer.WriteLine(message);
    }

    public void StartListening()
    {
        // Loop per ricevere e gestire i messaggi dal server
        while (tcpClient.Connected)
        {
            string receivedMessage = reader.ReadLine();
            if (receivedMessage == null)
                break;

            OnMessageReceived(receivedMessage);
        }
    }

    private void OnMessageReceived(string message)
    {
        // Richiama l'evento per gestire il messaggio ricevuto
        MessageReceived?.Invoke(message);
    }
}