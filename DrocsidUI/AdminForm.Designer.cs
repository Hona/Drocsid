namespace DrocsidUI
{
    partial class AdminForm
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
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.SendCommandLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommandTextBox.Location = new System.Drawing.Point(12, 34);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.Size = new System.Drawing.Size(775, 20);
            this.CommandTextBox.TabIndex = 0;
            this.CommandTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandTextBox_KeyDown);
            // 
            // SendCommandLabel
            // 
            this.SendCommandLabel.AutoSize = true;
            this.SendCommandLabel.Location = new System.Drawing.Point(13, 15);
            this.SendCommandLabel.Name = "SendCommandLabel";
            this.SendCommandLabel.Size = new System.Drawing.Size(93, 13);
            this.SendCommandLabel.TabIndex = 1;
            this.SendCommandLabel.Text = "Send a command:";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SendCommandLabel);
            this.Controls.Add(this.CommandTextBox);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CommandTextBox;
        private System.Windows.Forms.Label SendCommandLabel;
    }
}