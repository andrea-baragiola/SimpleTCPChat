// Client
using SimpleClient;

string serverIp = "127.0.0.1";

Console.Write("Inserisci tuo nome: ");
string name = Console.ReadLine();

Console.Write("Inserisci ID della chatroom: ");
int id = int.Parse(Console.ReadLine());

SimpleChatClient chatClient = new(name, id);
chatClient.MessageReceived += (message) =>
{
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
    string newMessage = Console.ReadLine();
    ClearLastLine();
    return newMessage;
}

