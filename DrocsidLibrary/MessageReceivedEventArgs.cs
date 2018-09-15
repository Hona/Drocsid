using System;

namespace DrocsidLibrary
{
    public class MessageReceivedEventArgs
    {
        public MessageReceivedEventArgs(string message, bool local = false)
        {
            Message = message;
            DateTimeReceived = DateTime.Now;
            SentLocally = local;
        }

        public string Message { get; }
        public DateTime DateTimeReceived { get; }
        public bool SentLocally { get; }
    }
}