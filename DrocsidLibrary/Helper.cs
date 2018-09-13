using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace DrocsidLibrary
{
    public static class Helper
    {
        public static string ConvertSkipToString(IEnumerable<char> array)
        {
            return string.Join(string.Empty, array);
        }
        public static IPAddress LocalIpAddress => Dns.GetHostEntry(Dns.GetHostName()).AddressList
            .First(ip => ip.AddressFamily == AddressFamily.InterNetwork);

        public static string FormatMessage(MessageReceivedEventArgs e)
        {
            return $"{e.DateTimeReceived.ToShortTimeString()}: {ConvertSkipToString(e.Message.Skip(1))}";
        }

        public static string FormatLogEntry(LogEventArgs e)
        {
            return $"[{e.Type.ToString().ToUpper()}] {e.DateTimeLogged.ToShortTimeString()}: {e.Message}";
        }

        public static string ApplySendFormat(MessageType type, string message)
        {
            return (int)type + message;
        }

        public static void ExecuteCommand(string message)
        {
            var fullCommand = ConvertSkipToString(message.Skip(1));
            if (string.IsNullOrWhiteSpace(fullCommand)) return;

            try
            {
                if (!fullCommand.Contains(' ')) Process.Start(fullCommand);
                else
                {
                    //Split the command and parameters
                    var splitCommand = fullCommand.Split(' ');
                    var commandName = splitCommand[0];
                    var arguments = splitCommand.Skip(1)
                        .Aggregate("", (argumentString, nextSplit) => argumentString + nextSplit);
                    Process.Start(commandName, arguments);
                }
            }
            catch
            {
                // Ignore errors client side
                // TODO: send message back to sender?
            }

        }
    }
}
