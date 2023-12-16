namespace WinFormsClient
{
    partial class ChatWinFormClient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sendButton = new Button();
            messageListTextBox = new RichTextBox();
            messageToSendTextBox = new RichTextBox();
            nameTextBox = new TextBox();
            SuspendLayout();
            // 
            // sendButton
            // 
            sendButton.Location = new Point(604, 305);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(75, 23);
            sendButton.TabIndex = 0;
            sendButton.Text = "send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // messageListTextBox
            // 
            messageListTextBox.Location = new Point(163, 52);
            messageListTextBox.Name = "messageListTextBox";
            messageListTextBox.Size = new Size(425, 214);
            messageListTextBox.TabIndex = 1;
            messageListTextBox.Text = "";
            // 
            // messageToSendTextBox
            // 
            messageToSendTextBox.Location = new Point(163, 305);
            messageToSendTextBox.Name = "messageToSendTextBox";
            messageToSendTextBox.Size = new Size(425, 54);
            messageToSendTextBox.TabIndex = 2;
            messageToSendTextBox.Text = "";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(165, 19);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(100, 23);
            nameTextBox.TabIndex = 3;
            nameTextBox.Text = "Anonimo";
            // 
            // ChatWinFormClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nameTextBox);
            Controls.Add(messageToSendTextBox);
            Controls.Add(messageListTextBox);
            Controls.Add(sendButton);
            Name = "ChatWinFormClient";
            Text = "WinFormChatClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendButton;
        private RichTextBox messageListTextBox;
        private RichTextBox messageToSendTextBox;
        private TextBox nameTextBox;
    }
}
