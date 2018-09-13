using System;

namespace DrocsidLibrary
{
    public class LogEventArgs
    {
        public LogEventArgs(LogType type, string message)
        {
            Type = type;
            Message = message;
            DateTimeLogged = DateTime.Now;
        }

        public LogType Type { get; }
        public string Message { get; }
        public DateTime DateTimeLogged { get; }
    }
}