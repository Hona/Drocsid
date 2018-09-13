using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace DrocsidLibrary
{
    internal class AsyncClientHandler
    {
        private readonly Logger _logger;
        private readonly StreamReader _reader;
        private readonly TcpClient _tcpClient;
        private readonly StreamWriter _writer;
        public EventHandler<MessageReceivedEventArgs> MessageReceived;

        public AsyncClientHandler(TcpClient client, Logger logger)
        {
            _tcpClient = client;
            _logger = logger;
            try
            {
                var networkStream = _tcpClient.GetStream();
                _reader = new StreamReader(networkStream);
                _writer = new StreamWriter(networkStream) {AutoFlush = true};
            }
            catch (Exception e)
            {
                logger.Log(LogType.Error, e.Message);
            }
        }

        public async Task ReadData()
        {
            try
            {
                while (_tcpClient.Connected)
                {
                    var message = await _reader.ReadLineAsync();
                    OnMessageReceived(message);
                }
            }
            catch (IOException)
            {
                _logger.Log(LogType.Info, $"Client at {_tcpClient.Client.RemoteEndPoint} disconnected");
            }
        }

        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        }

        public async void SendMessageAsync(string message)
        {
            try
            {
                await _writer.WriteLineAsync(message);
            }
            catch (IOException e)
            {
                _logger.Log(LogType.Error, $"{e.Message} (Do you have multiple clients open?)");
            }
        }
    }
}