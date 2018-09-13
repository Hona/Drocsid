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
            this.NameLabel = new System.Windows.Forms.Label();
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.IpAddressTextBox = new System.Windows.Forms.TextBox();
            this.PowerShellTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartServerButton
            // 
            this.StartServerButton.FlatAppearance.BorderSize = 0;
            this.StartServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartServerButton.Location = new System.Drawing.Point(12, 43);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(152, 23);
            this.StartServerButton.TabIndex = 0;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // StartClientButton
            // 
            this.StartClientButton.FlatAppearance.BorderSize = 0;
            this.StartClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartClientButton.Location = new System.Drawing.Point(12, 72);
            this.StartClientButton.Name = "StartClientButton";
            this.StartClientButton.Size = new System.Drawing.Size(152, 23);
            this.StartClientButton.TabIndex = 1;
            this.StartClientButton.Text = "Start Client";
            this.StartClientButton.UseVisualStyleBackColor = true;
            this.StartClientButton.Click += new System.EventHandler(this.StartClientButton_Click);
            // 
            // MessageLogTextBox
            // 
            this.MessageLogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageLogTextBox.ForeColor = System.Drawing.Color.White;
            this.MessageLogTextBox.Location = new System.Drawing.Point(170, 43);
            this.MessageLogTextBox.Multiline = true;
            this.MessageLogTextBox.Name = "MessageLogTextBox";
            this.MessageLogTextBox.ReadOnly = true;
            this.MessageLogTextBox.Size = new System.Drawing.Size(694, 320);
            this.MessageLogTextBox.TabIndex = 2;
            // 
            // SendMessageTextBox
            // 
            this.SendMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SendMessageTextBox.ForeColor = System.Drawing.Color.White;
            this.SendMessageTextBox.Location = new System.Drawing.Point(170, 369);
            this.SendMessageTextBox.Name = "SendMessageTextBox";
            this.SendMessageTextBox.Size = new System.Drawing.Size(694, 20);
            this.SendMessageTextBox.TabIndex = 3;
            this.SendMessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendMessageTextBox_KeyDown);
            // 
            // NameTextBox
            // 
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.ForeColor = System.Drawing.Color.White;
            this.NameTextBox.Location = new System.Drawing.Point(56, 101);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(108, 20);
            this.NameTextBox.TabIndex = 4;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 104);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "Name:";
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.AutoSize = true;
            this.IPAddressLabel.Location = new System.Drawing.Point(12, 130);
            this.IPAddressLabel.Name = "IPAddressLabel";
            this.IPAddressLabel.Size = new System.Drawing.Size(20, 13);
            this.IPAddressLabel.TabIndex = 7;
            this.IPAddressLabel.Text = "IP:";
            // 
            // IpAddressTextBox
            // 
            this.IpAddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IpAddressTextBox.ForeColor = System.Drawing.Color.White;
            this.IpAddressTextBox.Location = new System.Drawing.Point(38, 127);
            this.IpAddressTextBox.Name = "IpAddressTextBox";
            this.IpAddressTextBox.Size = new System.Drawing.Size(126, 20);
            this.IpAddressTextBox.TabIndex = 6;
            // 
            // PowerShellTextBox
            // 
            this.PowerShellTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PowerShellTextBox.ForeColor = System.Drawing.Color.White;
            this.PowerShellTextBox.Location = new System.Drawing.Point(170, 395);
            this.PowerShellTextBox.Name = "PowerShellTextBox";
            this.PowerShellTextBox.Size = new System.Drawing.Size(694, 20);
            this.PowerShellTextBox.TabIndex = 8;
            this.PowerShellTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PowerShellTextBox_KeyDown);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 423);
            this.Controls.Add(this.PowerShellTextBox);
            this.Controls.Add(this.IPAddressLabel);
            this.Controls.Add(this.IpAddressTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.SendMessageTextBox);
            this.Controls.Add(this.MessageLogTextBox);
            this.Controls.Add(this.StartClientButton);
            this.Controls.Add(this.StartServerButton);
            this.Name = "ChatForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.Button StartClientButton;
        private System.Windows.Forms.TextBox MessageLogTextBox;
        private System.Windows.Forms.TextBox SendMessageTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label IPAddressLabel;
        private System.Windows.Forms.TextBox IpAddressTextBox;
        private System.Windows.Forms.TextBox PowerShellTextBox;
    }
}

