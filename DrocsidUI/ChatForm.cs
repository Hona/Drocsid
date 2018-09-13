using System;
using System.Linq;
using System.Windows.Forms;
using DrocsidLibrary;

namespace DrocsidUI
{
    public partial class ChatForm : Form
    {
        // TODO: Autoscroll textbox
        // TODO: Add menubar with preferences
        // TODO: Add a debug option
        private AsyncClient _client;
        private readonly Logger _logger;
        private AsyncServer _server;
        private readonly User _user = new User();

        public ChatForm()
        {
            _logger = new Logger();
            _logger.LogEntryReceived += AppendLog;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SendMessageTextBox_Enter(object sender, EventArgs e)
        {
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            _server = new AsyncServer(_logger);
            _server.MessageReceived += ProcessMessage;
            _server.Run();
        }

        private void StartClientButton_Click(object sender, EventArgs e)
        {
            _client = new AsyncClient(Helper.LocalIpAddress, _logger);
            _client.MessageReceived += ProcessMessage;
            _client.ReceiveData();
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
                $"Converted type: {messageType.ToString()}. integer value: {Convert.ToInt32(e.Message.First().ToString())}");
            switch (messageType)
            {
                case MessageType.Message:
                    MessageLogTextBox.Text += Environment.NewLine + Helper.FormatMessage(e);
                    break;
                case MessageType.Command:
                    Helper.ExecuteCommand(e.Message);
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

            MessageLogTextBox.Text += Environment.NewLine + Helper.FormatLogEntry(e);
        }

        private void SendMessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var message = Helper.ApplySendFormat(MessageType.Message, SendMessageTextBox.Text);

            _client?.SendMessageAsync(message);
            _server?.SendMessageAsync(message);
            SendMessageTextBox.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            _user.Name = NameTextBox.Text;
        }

        private void PowerShellTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var message = Helper.ApplySendFormat(MessageType.Command, PowerShellTextBox.Text);

            _client?.SendMessageAsync(message);
            _server?.SendMessageAsync(message);
            PowerShellTextBox.Text = "";
        }
    }
}