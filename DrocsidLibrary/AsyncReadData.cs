using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace DrocsidLibrary
{
    /// <summary>
    ///     Provides functionality for reading data from a TcpClient, and firing events when received
    /// </summary>
    public class AsyncReadData
    {
        // Message printed when the server disconnects
        protected string IOExceptionMessage;

        protected Logger Logger;

        /// <summary>
        /// Fired when there is a new message
        /// </summary>
        public EventHandler<MessageReceivedEventArgs> MessageReceived;

        //All needed for TCP communications
        protected StreamReader Reader;
        protected TcpClient TcpClient;
        protected StreamWriter Writer;

        /// <summary>
        /// Reads data from the StreamReader until the TcpClient disconnects. Fires the event when new data is read
        /// </summary>
        public async Task ReadData()
        {
            //Handles the server closing
            try
            {
                while (TcpClient.Connected)
                {
                    //Wait for a new message
                    var message = await Reader.ReadLineAsync();
                    OnMessageReceived(message);
                }
            }
            catch (IOException)
            {
                //Occurs when the server closes
                Logger.Log(LogType.Info, IOExceptionMessage);
            }
        }

        protected void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        }
        /// <summary>
        /// Closes network streams, and the TCP client
        /// </summary>
        public void Stop()
        {
            Reader.Close();
            Writer.Close();
            TcpClient.Close();
        }
    }
}