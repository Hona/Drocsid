using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace DrocsidLibrary
{
    public class AsyncServer
    {
        private readonly List<AsyncClientHandler> _clientHandlers = new List<AsyncClientHandler>();
        private readonly Logger _logger;
        private TcpListener _tcpListener;
        public EventHandler<MessageReceivedEventArgs> MessageReceived;

        public AsyncServer(Logger logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Starts listening for clients
        /// </summary>
        public void Run()
        {
            _logger.Log(LogType.Info, $"Starting server on {Helper.LocalIpAddress}:{Constants.Port}");
            _tcpListener = new TcpListener(Helper.LocalIpAddress, Constants.Port);
            _tcpListener.Start();

            AcceptClients();
        }

        private async void AcceptClients()
        {
            _logger.Log(LogType.Info, "Accepting clients");
            while (true)
                try
                {
                    var newClient = await _tcpListener.AcceptTcpClientAsync();
                    ProcessClient(newClient);
                }
                catch (Exception e)
                {
                    _logger.Log(LogType.Warning, e.Message);
                }
        }

        /// <summary>
        ///     Handles each Client connection asynchronously
        /// </summary>
        /// <returns></returns>
        private async void ProcessClient(TcpClient client)
        {
            _logger.Log(LogType.Info, $"Client connected from {client.Client.RemoteEndPoint}");
            var handler = new AsyncClientHandler(client, _logger);

            handler.MessageReceived += HandleNewMessage;
            _clientHandlers.Add(handler);
            await handler.ReadData();
        }

        private void HandleNewMessage(object sender, MessageReceivedEventArgs e)
        {
            foreach (var handler in _clientHandlers)
            {
                if (handler == sender as AsyncClientHandler) continue;
                handler.SendMessageAsync(e.Message);
            }

            // Sends to the UI
            OnMessageReceived(e);
        }

        public void SendMessageAsync(string message)
        {
            foreach (var handler in _clientHandlers) handler.SendMessageAsync(message);
        }

        protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
        {
            MessageReceived?.Invoke(this, e);
        }
    }
}