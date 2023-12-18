using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace WinFormsClient
{
    public partial class ChatWinFormClient : Form
    {
        public int RoomId { get; set; }
        public string SenderName { get; set; }
        private System.Windows.Forms.Timer timer;
        public ChatWinFormClient(int roomId, string senderName)
        {
            InitializeComponent();
            timer = new();
            timer.Interval = 1000;
            timer.Tick += TimerTick;
            timer.Start();
            RoomId = roomId;
            SenderName = senderName;
            senderNameLabel.Text = SenderName;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //UpdateChat();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string messageSender = senderNameLabel.Text;
            string messageContent = messageToSendTextBox.Text;
            SendMessage(messageSender, messageContent);
            messageToSendTextBox.Text = string.Empty;
        }

        private void SendMessage(string messageSender, string messageContent)
        {
            Message message = new(messageSender, messageContent);

            string requestBody = JsonSerializer.Serialize(message);
            string postUrl = "https://localhost:7236/api/Chat/post";

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(postUrl, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine($"Error: {response.StatusCode} - {errorMessage}");
                }
            }
        }

        private void UpdateChat()
        {
            string getAllUrl = "https://localhost:7236/api/Chat/all";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(getAllUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    List<string>? messages = JsonSerializer.Deserialize<List<string>>(responseData);
                    if (messages != null)
                    {
                        messageListTextBox.Text = string.Join("\n", messages);
                    }
                }
            }
        }
    }
}
