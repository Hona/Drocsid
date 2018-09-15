using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace DrocsidLibrary
{
    public static class Helper
    {
        public static IPAddress LocalIpAddress => Dns.GetHostEntry(Dns.GetHostName()).AddressList
            .First(ip => ip.AddressFamily == AddressFamily.InterNetwork);

        private static string ConvertSkipToString(IEnumerable<char> array)
        {
            return string.Join(string.Empty, array);
        }

        public static string FormatMessage(MessageReceivedEventArgs e)
        {
            return $"{e.DateTimeReceived.ToShortTimeString()}: {ConvertSkipToString(e.Message.Skip(1))}";
        }

        public static string FormatLogEntry(LogEventArgs e)
        {
            return $"[{e.Type.ToString().ToUpper()}] {e.DateTimeLogged.ToShortTimeString()}: {e.Message}";
        }

        public static string ApplySendFormat(MessageType type, User user, string message)
        {
            switch (type)
            {
                case MessageType.Message:
                    return (int) type + $"{user.Name}: " + message;
                case MessageType.Command:
                    return (int) type + message;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static void ExecuteCommand(MessageReceivedEventArgs eventArgs, Logger logger)
        {
            if (eventArgs.SentLocally) return;
            var fullCommand = ConvertSkipToString(eventArgs.Message.Skip(1));
            if (string.IsNullOrWhiteSpace(fullCommand)) return;

            try
            {
                if (!fullCommand.Contains(' '))
                {
                    Process.Start(fullCommand);
                }
                else
                {
                    //Split the command and parameters
                    var splitCommand = fullCommand.Split(new[] {' '}, 2);
                    var startInfo = new ProcessStartInfo(splitCommand[0], splitCommand[1]);
                    Process.Start(startInfo);
                }
            }
            catch (Exception e)
            {
                logger.Log(LogType.Debug, e.Message);
                // Ignore errors client side
                // TODO: send message back to sender?
            }
        }
    }
}