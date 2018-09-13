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
        private bool _acceptClients;

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

            _acceptClients = true;
            AcceptClientsAsync();
        }
        /// <summary>
        /// Accepts incoming connections until close
        /// </summary>
        private async void AcceptClientsAsync()
        {
            _logger.Log(LogType.Info, "Accepting clients");
            while (_acceptClients)
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
        private async void ProcessClient(TcpClient client)
        {
            _logger.Log(LogType.Info, $"Client connected from {client.Client.RemoteEndPoint}");
            var handler = new AsyncClientHandler(client, _logger);

            handler.MessageReceived += DistributeClientMessage;
            _clientHandlers.Add(handler);
            await handler.ReadData();
        }
        /// <summary>
        /// Sends client message to all other clients, and fires the event
        /// </summary>
        /// <param name="sender">The sending AsyncClientHandler</param>
        /// <param name="e">Contains the message and timestamp</param>
        private void DistributeClientMessage(object sender, MessageReceivedEventArgs e)
        {
            foreach (var handler in _clientHandlers)
            {
                if (handler == sender as AsyncClientHandler) continue;
                handler.SendMessageAsync(e.Message);
            }

            // Sends to the UI
            OnMessageReceived(e);
        }
        private void OnMessageReceived(MessageReceivedEventArgs e)
        {
            MessageReceived?.Invoke(this, e);
        }
        /// <summary>
        /// Sends a message to all client handlers
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageAsync(string message)
        {
            foreach (var handler in _clientHandlers) handler.SendMessageAsync(message);
            //Hook into received messages to write your own message
            OnMessageReceived(new MessageReceivedEventArgs(message));
        }

        public void Stop()
        {
            _acceptClients = false;
            foreach (var handler in _clientHandlers)
            {
                handler.Stop();
            }
            _tcpListener.Stop();
        }

    }
}