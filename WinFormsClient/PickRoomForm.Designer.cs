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
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // room1Button
            // 
            room1Button.Location = new Point(69, 91);
            room1Button.Name = "room1Button";
            room1Button.Size = new Size(75, 23);
            room1Button.TabIndex = 0;
            room1Button.Text = "room1";
            room1Button.UseVisualStyleBackColor = true;
            room1Button.Click += room1Button_Click;
            // 
            // room2Button
            // 
            room2Button.Location = new Point(150, 91);
            room2Button.Name = "room2Button";
            room2Button.Size = new Size(75, 23);
            room2Button.TabIndex = 1;
            room2Button.Text = "room2";
            room2Button.UseVisualStyleBackColor = true;
            room2Button.Click += room2Button_Click;
            // 
            // senderNameTextBox
            // 
            senderNameTextBox.Location = new Point(69, 38);
            senderNameTextBox.Name = "senderNameTextBox";
            senderNameTextBox.Size = new Size(100, 23);
            senderNameTextBox.TabIndex = 2;
            senderNameTextBox.Text = "Default";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 20);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 3;
            label1.Text = "Write your name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 73);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 4;
            label2.Text = "Pick a room:";
            // 
            // PickRoomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 202);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
    }
}