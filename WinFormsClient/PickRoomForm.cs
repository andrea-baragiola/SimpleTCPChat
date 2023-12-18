using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class PickRoomForm : Form
    {
        public PickRoomForm()
        {
            InitializeComponent();
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
    }
}
