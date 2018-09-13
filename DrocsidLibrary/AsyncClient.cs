using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace DrocsidLibrary
{
    public class AsyncClient
    {
        private readonly Logger _logger;
        private readonly StreamReader _reader;
        private readonly TcpClient _tcpClient;
        private readonly StreamWriter _writer;
        public EventHandler<MessageReceivedEventArgs> MessageReceived;

        public AsyncClient(IPAddress serverAddress, Logger logger)
        {
            _logger = logger;
            _tcpClient = new TcpClient();
            _logger.Log(LogType.Info, $"Connecting to {serverAddress}:{Constants.Port}");
            _tcpClient.Connect(serverAddress, Constants.Port);
            try
            {
                var networkStream = _tcpClient.GetStream();
                _reader = new StreamReader(networkStream);
                _writer = new StreamWriter(networkStream) {AutoFlush = true};
            }
            catch
            {
                _logger.Log(LogType.Warning, "Could not connect to the server");
            }
        }

        public async void ReceiveData()
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
                _logger.Log(LogType.Info, "Server closed the connection");
            }
        }

        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        }

        public async void SendMessageAsync(string message)
        {
            await _writer.WriteLineAsync(message);
        }
    }
}