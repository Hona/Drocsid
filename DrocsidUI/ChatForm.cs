using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using DrocsidLibrary;

namespace DrocsidUI
{
    public partial class ChatForm : Form
    {
        // TODO: Add menubar with preferences
        // TODO: Add a debug option

        private readonly Logger _logger;
        internal readonly User User = new User();
        private readonly Settings _settings;

        internal AsyncClient Client;
        internal AsyncServer Server;

        public ChatForm()
        {
            _settings = Settings.DeserialseFromFile();
            _logger = new Logger(_settings);

            _logger.LogEntryReceived += AppendLog;
            InitializeComponent();

            ApplyDarkColors();
        }

        private void ApplyDarkColors()
        {
            BackColor = CustomColors.Darkest;
            MessageLogTextBox.BackColor = CustomColors.Dark;
            SendMessageTextBox.BackColor = CustomColors.LightGray;

            StartClientButton.BackColor = CustomColors.Darker;
            StartServerButton.BackColor = CustomColors.Darker;
            StartClientButton.ForeColor = Color.White;
            StartServerButton.ForeColor = Color.White;

            IPAddressLabel.ForeColor = Color.White;
            NameLabel.ForeColor = Color.White;

            IpAddressTextBox.BackColor = CustomColors.LightGray;
            NameTextBox.BackColor = CustomColors.LightGray;
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            Server = new AsyncServer(_logger);
            Server.MessageReceived += ProcessMessage;
            Server.Run();
        }

        private async void StartClientButton_Click(object sender, EventArgs e)
        {
            // If no IP is specified then connect to the local host
            var address = IpAddressTextBox.Text == ""
                ? Helper.LocalIpAddress
                : IPAddress.Parse(IpAddressTextBox.Text);
            Client = new AsyncClient(_logger);
            await Client.Connect(address);
            Client.MessageReceived += ProcessMessage;
            await Client.ReadData();
        }

        private void ProcessMessage(object sender, MessageReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, MessageReceivedEventArgs>(ProcessMessage), sender, e);
                return;
            }

            var messageType = (MessageType) Convert.ToInt32(e.Message.First().ToString());
            _logger.Log(LogType.Debug,
                $"Converted type: {messageType}. integer value: {Convert.ToInt32(e.Message.First().ToString())}");
            switch (messageType)
            {
                case MessageType.Message:
                    MessageLogTextBox.AppendText(Environment.NewLine + Helper.FormatMessage(e));
                    break;
                case MessageType.Command:
                    Helper.ExecuteCommand(e, _logger);
                    break;
                default:
                    _logger.Log(LogType.Error, $"Could not determine message type: {e.Message}");
                    break;
            }
        }

        private void AppendLog(object sender, LogEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, LogEventArgs>(AppendLog), sender, e);
                return;
            }

            MessageLogTextBox.AppendText(Environment.NewLine + Helper.FormatLogEntry(e));
        }

        private void SendMessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var message = Helper.ApplySendFormat(MessageType.Message, User, SendMessageTextBox.Text);

            Client?.SendMessageAsync(message);
            Server?.SendMessageAsync(message);
            SendMessageTextBox.Text = "";
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            User.Name = NameTextBox.Text;
        }

        private void AdminButton_Click(object sender, EventArgs e)
        {
            if (SendMessageTextBox.Text == Constants.Password)
            {
                var adminForm = new AdminForm(this);
                adminForm.Show();
            }
            else
            {
                _logger.Log(LogType.Warning,
                    "You are not admin, if you think this is an error, please contact the developer");
            }
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.SerialiseToFile();
            Client?.Stop();
            Server?.Stop();
        }
    }
}