using System;
using System.IO;
using System.Net.Sockets;

namespace DrocsidLibrary
{
    internal class AsyncClientHandler : AsyncReadData
    {
        public AsyncClientHandler(TcpClient client, Logger logger)
        {
            TcpClient = client;
            Logger = logger;

            // Custom disconnect message
            IoExceptionMessage = $"Client at {TcpClient.Client.RemoteEndPoint} disconnected";

            try
            {
                var networkStream = TcpClient.GetStream();
                Reader = new StreamReader(networkStream);
                Writer = new StreamWriter(networkStream) {AutoFlush = true};
            }
            catch (Exception e)
            {
                logger.Log(LogType.Error, e.Message);
            }
        }

        /// <summary>
        ///     Writes a message to the server
        /// </summary>
        /// <param name="message"></param>
        public async void SendMessageAsync(string message)
        {
            try
            {
                await Writer.WriteLineAsync(message);
            }
            catch (IOException e)
            {
                Logger.Log(LogType.Error, $"{e.Message}");
            }
        }
    }
}