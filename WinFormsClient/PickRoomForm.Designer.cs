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
            room1Button = new Button();
            room2Button = new Button();
            senderNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // room1Button
            // 
            room1Button.Location = new Point(157, 109);
            room1Button.Name = "room1Button";
            room1Button.Size = new Size(75, 23);
            room1Button.TabIndex = 0;
            room1Button.Text = "room1";
            room1Button.UseVisualStyleBackColor = true;
            room1Button.Click += room1Button_Click;
            // 
            // room2Button
            // 
            room2Button.Location = new Point(248, 109);
            room2Button.Name = "room2Button";
            room2Button.Size = new Size(75, 23);
            room2Button.TabIndex = 1;
            room2Button.Text = "room2";
            room2Button.UseVisualStyleBackColor = true;
            room2Button.Click += room2Button_Click;
            // 
            // senderNameTextBox
            // 
            senderNameTextBox.Location = new Point(158, 45);
            senderNameTextBox.Name = "senderNameTextBox";
            senderNameTextBox.Size = new Size(100, 23);
            senderNameTextBox.TabIndex = 2;
            senderNameTextBox.Text = "Default";
            // 
            // PickRoomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(senderNameTextBox);
            Controls.Add(room2Button);
            Controls.Add(room1Button);
            Name = "PickRoomForm";
            Text = "PickSeverForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button room1Button;
        private Button room2Button;
        private TextBox senderNameTextBox;
    }
}