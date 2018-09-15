using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace DrocsidLibrary
{
    public class AsyncClient : AsyncReadData
    {
        public AsyncClient(Logger logger)
        {
            Logger = logger;
            TcpClient = new TcpClient();

            //Custom disconnect message
            IoExceptionMessage = "Server closed the connection";
        }

        public async Task Connect(IPAddress serverAddress)
        {
            Logger.Log(LogType.Info, $"Connecting to {serverAddress}:{Constants.Port}");
            //Waits for the client to connect
            try
            {
                await TcpClient.ConnectAsync(serverAddress, Constants.Port);
                //Get the StreamReader/Writer from the TcpClients network stream
                var networkStream = TcpClient.GetStream();
                Reader = new StreamReader(networkStream);

                //AutoFlush automatically sends data written
                Writer = new StreamWriter(networkStream) {AutoFlush = true};
            }
            catch
            {
                Logger.Log(LogType.Warning, "Could not connect to the server");
                Stop();
            }
        }

        public async void SendMessageAsync(string message)
        {
            await Writer.WriteLineAsync(message);

            //Hooks into the received message to write your own message
            OnMessageReceived(message, true);
        }
    }
}