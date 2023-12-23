namespace WinFormsClient
{
    partial class PickRoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            senderNameTextBox = new TextBox();
            label1 = new Label();
            label3 = new Label();
            roomsListBox = new ListBox();
            createRoomButton = new Button();
            SuspendLayout();
            // 
            // senderNameTextBox
            // 
            senderNameTextBox.Location = new Point(12, 27);
            senderNameTextBox.Name = "senderNameTextBox";
            senderNameTextBox.Size = new Size(100, 23);
            senderNameTextBox.TabIndex = 2;
            senderNameTextBox.Text = "Default";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 3;
            label1.Text = "Write your name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 62);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 5;
            label3.Text = "Available rooms:";
            // 
            // roomsListBox
            // 
            roomsListBox.FormattingEnabled = true;
            roomsListBox.ItemHeight = 15;
            roomsListBox.Location = new Point(12, 80);
            roomsListBox.Name = "roomsListBox";
            roomsListBox.Size = new Size(120, 169);
            roomsListBox.TabIndex = 6;
            roomsListBox.DoubleClick += roomsListBox_DoubleClick;
            // 
            // createRoomButton
            // 
            createRoomButton.Location = new Point(148, 80);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(75, 39);
            createRoomButton.TabIndex = 7;
            createRoomButton.Text = "Create New Room";
            createRoomButton.UseVisualStyleBackColor = true;
            createRoomButton.Click += createRoomButton_Click;
            // 
            // PickRoomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 303);
            Controls.Add(createRoomButton);
            Controls.Add(roomsListBox);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(senderNameTextBox);
            Name = "PickRoomForm";
            Text = "PickSeverForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox senderNameTextBox;
        private Label label1;
        private Label label3;
        private ListBox roomsListBox;
        private Button createRoomButton;
    }
}