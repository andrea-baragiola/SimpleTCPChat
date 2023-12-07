// Client
using System;
using SimpleTCPChatLibrary;

//Console.Write("Inserisci l'indirizzo IP del server: ");
//string serverIp = Console.ReadLine();
string serverIp = "127.0.0.1";

Console.Write("Inserisci tuo nome: ");
string name = Console.ReadLine();

SimpleChatClient chatClient = new(name);
chatClient.MessageReceived += (message) =>
{
    //ClearLastLine();
    Console.WriteLine(message);

};

// Connessione al server
chatClient.Connect(serverIp, 8888);

// Avvia il thread per l'ascolto continuo dei messaggi dal server
Task.Run(() => chatClient.StartListening());

// Loop per inviare messaggi al server
while (true)
{
    string newMessage = GrabMessageFromUser();
    chatClient.SendMessage(newMessage);
    Thread.Sleep(1000);
}
static void ClearLastLine()
{
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    Console.WriteLine("                                   ");
    Console.SetCursorPosition(0, Console.CursorTop - 1);
}

static string GrabMessageFromUser()
{
    //Console.Write("Scrivi Messaggio: ");
    string newMessage = Console.ReadLine();
    ClearLastLine();
    return newMessage;
}

