using System.Drawing;
using System.Windows.Forms;
using DrocsidLibrary;

namespace DrocsidUI
{
    public partial class AdminForm : Form
    {
        private readonly ChatForm _chatForm;

        public AdminForm(ChatForm chatForm)
        {
            _chatForm = chatForm;
            InitializeComponent();

            ApplyDarkTheme();
        }

        private void CommandTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var message = Helper.ApplySendFormat(MessageType.Command, _chatForm.User, CommandTextBox.Text);

            _chatForm.Client?.SendMessageAsync(message);
            _chatForm.Server?.SendMessageAsync(message);

            CommandTextBox.Text = "";
        }

        private void ApplyDarkTheme()
        {
            SendCommandLabel.ForeColor = Color.White;
            BackColor = CustomColors.Darkest;
            CommandTextBox.BackColor = CustomColors.Darker;
            CommandTextBox.ForeColor = Color.White;
        }
    }
}