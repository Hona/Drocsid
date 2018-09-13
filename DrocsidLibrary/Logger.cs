using System;

namespace DrocsidLibrary
{
    public class Logger
    {
        public EventHandler<LogEventArgs> LogEntryReceived;

        public void Log(LogType type, string message)
        {
            // TODO: Make this a preference on the UI
            if (type == LogType.Debug) return;
            OnLogEntryReceoved(new LogEventArgs(type, message));
        }

        protected virtual void OnLogEntryReceoved(LogEventArgs e)
        {
            LogEntryReceived?.Invoke(this, e);
        }
    }
}