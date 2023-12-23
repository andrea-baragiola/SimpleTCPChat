using SimpleServer;

SimpleChatServer chatServer = new SimpleChatServer();
chatServer.MessageReceived += (message) => Console.WriteLine(message);

Console.WriteLine("Server avviato. In attesa di connessioni...");

// start the server
chatServer.Start();



// Attendi l'input dell'utente per terminare il server
Console.WriteLine("Premi Enter per terminare il server.");
Console.ReadLine();
