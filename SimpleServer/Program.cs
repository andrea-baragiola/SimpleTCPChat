using SimpleTCPChatLibrary;


SimpleChatServer chatServer = new SimpleChatServer();
chatServer.MessageReceived += (message) => Console.WriteLine(message);

// start the server
chatServer.Start();

Console.WriteLine("Server avviato. In attesa di connessioni...");

// Attendi l'input dell'utente per terminare il server
Console.WriteLine("Premi Enter per terminare il server.");
Console.ReadLine();
