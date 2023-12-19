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
            senderNameLabel = new Label();
            chatLabel = new Label();
            confirmationMessageLabel = new Label();
            SuspendLayout();
            // 
            // sendButton
            // 
            sendButton.Location = new Point(465, 301);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(75, 23);
            sendButton.TabIndex = 0;
            sendButton.Text = "send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // messageListTextBox
            // 
            messageListTextBox.Location = new Point(24, 48);
            messageListTextBox.Name = "messageListTextBox";
            messageListTextBox.Size = new Size(425, 214);
            messageListTextBox.TabIndex = 1;
            messageListTextBox.Text = "";
            // 
            // messageToSendTextBox
            // 
            messageToSendTextBox.Location = new Point(24, 301);
            messageToSendTextBox.Name = "messageToSendTextBox";
            messageToSendTextBox.Size = new Size(425, 54);
            messageToSendTextBox.TabIndex = 2;
            messageToSendTextBox.Text = "";
            // 
            // senderNameLabel
            // 
            senderNameLabel.AutoSize = true;
            senderNameLabel.Location = new Point(24, 283);
            senderNameLabel.Name = "senderNameLabel";
            senderNameLabel.Size = new Size(117, 15);
            senderNameLabel.TabIndex = 3;
            senderNameLabel.Text = "defaultToBeChanged";
            // 
            // chatLabel
            // 
            chatLabel.AutoSize = true;
            chatLabel.Location = new Point(24, 30);
            chatLabel.Name = "chatLabel";
            chatLabel.Size = new Size(32, 15);
            chatLabel.TabIndex = 6;
            chatLabel.Text = "Chat";
            // 
            // confirmationMessageLabel
            // 
            confirmationMessageLabel.AutoSize = true;
            confirmationMessageLabel.Location = new Point(24, 358);
            confirmationMessageLabel.Name = "confirmationMessageLabel";
            confirmationMessageLabel.Size = new Size(31, 15);
            confirmationMessageLabel.TabIndex = 7;
            confirmationMessageLabel.Text = "        ";
            // 
            // ChatWinFormClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(confirmationMessageLabel);
            Controls.Add(chatLabel);
            Controls.Add(senderNameLabel);
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
        private Label senderNameLabel;
        private Label chatLabel;
        private Label confirmationMessageLabel;
    }
}
