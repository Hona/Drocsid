using System;

namespace DrocsidLibrary
{
    public class Logger
    {
        public EventHandler<LogEventArgs> LogEntryReceived;

        public void Log(LogType type, string message)
        {
            OnLogEntryReceoved(new LogEventArgs(type, message));
        }

        protected virtual void OnLogEntryReceoved(LogEventArgs e)
        {
            LogEntryReceived?.Invoke(this, e);
        }
    }
}