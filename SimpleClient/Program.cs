// Client
using SimpleClient;

// chiedere informazioni
Console.Write("Inserisci tuo nome: ");
string name = Console.ReadLine();

// istanziare client
SimpleChatClient chatClient = new(name);

// Write all existing messages
foreach (string message in chatClient.Messages)
{
    Console.WriteLine(message);
}


// Avvia il thread per eseguire la GET request ogni 2 secondi
Thread getRequestThread = new Thread(() => PerformGetRequestEveryFiveSeconds(chatClient));
getRequestThread.Start();


// Avvia il thread per inviare messaggi
Thread sendMessagesThread = new Thread(() => MessageWriter(chatClient));
sendMessagesThread.Start();

// ---------------------------------------------
// ---------------------------------------------
// ---------------------------------------------
// ---------------------------------------------
// ---------------------------------------------

static void PerformGetRequestEveryFiveSeconds(SimpleChatClient chatClient)
{
    while (true)
    {
        chatClient.AddNewMessages();
        Console.Clear();
        foreach (string message in chatClient.Messages)
        {
            Console.WriteLine(message);
        }
        Thread.Sleep(5000);
    }
}

static void MessageWriter(SimpleChatClient chatClient)
{
    while (true)
    {
        string newMessage = Console.ReadLine();
        //Console.SetCursorPosition(0, Console.CursorTop - 1);
        //Console.WriteLine("                                   ");
        //Console.SetCursorPosition(0, Console.CursorTop - 1);
        chatClient.SendMessage(newMessage);
    }
}
