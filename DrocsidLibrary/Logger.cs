using System;

namespace DrocsidLibrary
{
    public class Logger
    {
        private readonly Settings _settings;
        public EventHandler<LogEventArgs> LogEntryReceived;

        public Logger(Settings settings)
        {
            _settings = settings;
        }

        public void Log(LogType type, string message)
        {
            if (type == LogType.Debug && !_settings.ShowDebugLogs) return;
            OnLogEntryReceoved(new LogEventArgs(type, message));
        }

        private void OnLogEntryReceoved(LogEventArgs e)
        {
            LogEntryReceived?.Invoke(this, e);
        }
    }
}