using System.Text.Json;
using WinFormsClient.APIClient;
using WinFormsClient.Models;

namespace WinFormsClient
{
    public partial class ChatWinFormClient : Form
    {

        private readonly System.Windows.Forms.Timer _timer;
        private readonly ChatAPIClient _chatAPIClient;

        public string SenderName { get; set; }

        public ChatWinFormClient(int roomId, string senderName)
        {
            InitializeComponent();
            _chatAPIClient = new(roomId); // instatiate API client related to a specific room
            SenderName = senderName;
            senderNameLabel.Text = SenderName;
            _timer = new();
            ActivateTimer();
        }

        // Starts the timer that will trigger the periodic update of the chat
        private void ActivateTimer()
        {
            _timer.Interval = 1000;
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            RefreshChatAsync();
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            string messageSender = senderNameLabel.Text;
            string messageContent = messageToSendTextBox.Text;
            HttpResponseMessage response = await _chatAPIClient.SendAsync(messageSender, messageContent);
            messageToSendTextBox.Text = string.Empty;
            if (response.IsSuccessStatusCode)  // provides delayed confirmation of sent message, without interrupting the main thread
            {
                await Task.Delay(3000);
                confirmationMessageLabel.Text = "message sent and received by the server";
                await Task.Delay(1000);
                confirmationMessageLabel.Text = string.Empty;
            }
        }

        // Reloads the messages of the chat
        private async Task RefreshChatAsync()
        {
            HttpResponseMessage response = await _chatAPIClient.GetMessagesAsync();
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                string responseData = await response.Content.ReadAsStringAsync();
                IEnumerable<ClientMessage>? messages = JsonSerializer.Deserialize<IEnumerable<ClientMessage>>(responseData, options);
                if (messages != null)
                {
                    messageListTextBox.Text = string.Join("\n", messages.Select(message => $"{message.MessageSender} : {message.Content}"));
                }
            }
        }

    }


}

