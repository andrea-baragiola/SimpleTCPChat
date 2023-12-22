using System.Text.Json;
using WinFormsClient.APIClient;

namespace WinFormsClient
{
    public partial class PickRoomForm : Form
    {
        public PickRoomForm()
        {
            InitializeComponent();
            UpdateRooms();
        }

        private void room1Button_Click(object sender, EventArgs e)
        {
            ChatWinFormClient chatWinFormClient = new(1, senderNameTextBox.Text);
            chatWinFormClient.ShowDialog();
        }

        private void room2Button_Click(object sender, EventArgs e)
        {
            ChatWinFormClient chatWinFormClient = new(2, senderNameTextBox.Text);
            chatWinFormClient.ShowDialog();
        }

        private async void createRoomButton_Click(object sender, EventArgs e)
        {
            await APIUtils.CreateRoomAsync();
            UpdateRooms();
        }

        private async Task UpdateRooms()
        {
            roomsListBox.Items.Clear();
            var response = await APIUtils.GetRoomIdsAsync();
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                List<int>? roomIds = JsonSerializer.Deserialize<List<int>>(responseData);
                foreach (int id in roomIds)
                {
                    roomsListBox.Items.Add(id);
                }
            }
        }

        private void roomsListBox_DoubleClick(object sender, EventArgs e)
        {
            int roomId = int.Parse(roomsListBox.SelectedItems[0].ToString());  // parse may be insecure
            ChatWinFormClient chatWinFormClient = new(roomId,senderNameTextBox.Text);
            chatWinFormClient.ShowDialog();
        }
    }
}
