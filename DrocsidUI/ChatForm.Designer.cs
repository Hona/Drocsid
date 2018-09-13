namespace DrocsidUI
{
    partial class ChatForm
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
            this.StartServerButton = new System.Windows.Forms.Button();
            this.StartClientButton = new System.Windows.Forms.Button();
            this.MessageLogTextBox = new System.Windows.Forms.TextBox();
            this.SendMessageTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IpAddressTextBox = new System.Windows.Forms.TextBox();
            this.PowerShellTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartServerButton
            // 
            this.StartServerButton.Location = new System.Drawing.Point(13, 13);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(75, 23);
            this.StartServerButton.TabIndex = 0;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // StartClientButton
            // 
            this.StartClientButton.Location = new System.Drawing.Point(94, 13);
            this.StartClientButton.Name = "StartClientButton";
            this.StartClientButton.Size = new System.Drawing.Size(75, 23);
            this.StartClientButton.TabIndex = 1;
            this.StartClientButton.Text = "Start Client";
            this.StartClientButton.UseVisualStyleBackColor = true;
            this.StartClientButton.Click += new System.EventHandler(this.StartClientButton_Click);
            // 
            // MessageLogTextBox
            // 
            this.MessageLogTextBox.Location = new System.Drawing.Point(13, 43);
            this.MessageLogTextBox.Multiline = true;
            this.MessageLogTextBox.Name = "MessageLogTextBox";
            this.MessageLogTextBox.Size = new System.Drawing.Size(600, 320);
            this.MessageLogTextBox.TabIndex = 2;
            // 
            // SendMessageTextBox
            // 
            this.SendMessageTextBox.Location = new System.Drawing.Point(13, 369);
            this.SendMessageTextBox.Name = "SendMessageTextBox";
            this.SendMessageTextBox.Size = new System.Drawing.Size(600, 20);
            this.SendMessageTextBox.TabIndex = 3;
            this.SendMessageTextBox.Enter += new System.EventHandler(this.SendMessageTextBox_Enter);
            this.SendMessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendMessageTextBox_KeyDown);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(234, 15);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 4;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // IpAddressTextBox
            // 
            this.IpAddressTextBox.Location = new System.Drawing.Point(382, 15);
            this.IpAddressTextBox.Name = "IpAddressTextBox";
            this.IpAddressTextBox.Size = new System.Drawing.Size(174, 20);
            this.IpAddressTextBox.TabIndex = 6;
            // 
            // PowerShellTextBox
            // 
            this.PowerShellTextBox.Location = new System.Drawing.Point(13, 395);
            this.PowerShellTextBox.Name = "PowerShellTextBox";
            this.PowerShellTextBox.Size = new System.Drawing.Size(600, 20);
            this.PowerShellTextBox.TabIndex = 8;
            this.PowerShellTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PowerShellTextBox_KeyDown);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 433);
            this.Controls.Add(this.PowerShellTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IpAddressTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.SendMessageTextBox);
            this.Controls.Add(this.MessageLogTextBox);
            this.Controls.Add(this.StartClientButton);
            this.Controls.Add(this.StartServerButton);
            this.Name = "ChatForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.Button StartClientButton;
        private System.Windows.Forms.TextBox MessageLogTextBox;
        private System.Windows.Forms.TextBox SendMessageTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IpAddressTextBox;
        private System.Windows.Forms.TextBox PowerShellTextBox;
    }
}

