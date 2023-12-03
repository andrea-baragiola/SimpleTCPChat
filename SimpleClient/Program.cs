// Client
using System;
using SimpleTCPChatLibrary;

class Program
{
    static void Main()
    {
        Console.Write("Inserisci l'indirizzo IP del server: ");
        string serverIp = Console.ReadLine();

        SimpleChatClient chatClient = new SimpleChatClient();
        //chatClient.MessageReceived += (message) => Console.WriteLine(message);

        // Connessione al server
        chatClient.Connect(serverIp, 8888);

        // Avvia il thread per l'ascolto continuo dei messaggi dal server
        Task.Run(() => chatClient.StartListening());

        // Loop per inviare messaggi al server
        while (true)
        {
            Console.Write("Messaggio: ");
            string message = Console.ReadLine();

            // Invia il messaggio al server
            chatClient.SendMessage(message);
        }
    }
}
