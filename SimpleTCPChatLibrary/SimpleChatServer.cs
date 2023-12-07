using System.Net;
using System.Net.Sockets;

namespace SimpleTCPChatLibrary
{
    public class SimpleChatServer
    {
        private TcpListener tcpListener;
        private List<TcpClient> clients = new List<TcpClient>();

        // Evento per gestire i messaggi ricevuti
        public event Action<string> MessageReceived;

        public void Start()
        {
            // Inizia ad accettare le connessioni
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();  // stato base del server
                clients.Add(client);

                // Gestisci il client in un thread separato
                Task.Run(() => HandleClient(client));
            }
        }

        private void HandleClient(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream());
            //StreamWriter writer = new StreamWriter(client.GetStream()) { AutoFlush = true };

            //writer.WriteLine("Benvenuto nella chat!");

            while (client.Connected)
            {
                string message = reader.ReadLine();
                if (message == null)
                    break;

                OnMessageReceived(message);
            }

            clients.Remove(client);
            client.Close();
        }

        private void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(message);

            // Invia il messaggio a tutti i client
            foreach (TcpClient client in clients)
            {
                StreamWriter writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
                writer.WriteLineAsync(message);
            }
        }
    }
}