using System;

namespace DrocsidLibrary
{
    public class MessageReceivedEventArgs
    {
        public MessageReceivedEventArgs(string message)
        {
            Message = message;
            DateTimeReceived = DateTime.Now;
        }

        public string Message { get; }
        public DateTime DateTimeReceived { get; }
    }
}