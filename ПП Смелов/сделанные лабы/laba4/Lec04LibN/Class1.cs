using System;
using System.IO;
using System.Text;

namespace Lec04LibN
{
    public interface ILogger
    {
        void start(string title);
        void log(string message);
        void stop();
    }

    public partial class Logger : ILogger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private StreamWriter _logWriter;
        private int _namespaceLevel = 0;
        private bool _disposed = false;
        private int _logEntryNumber = 0;

        private Logger()
        {
            string logFileName = string.Format(@"{0}/LOG{1}.txt", Directory.GetCurrentDirectory(), DateTime.Now.ToString("yyyyMMdd-HH-mm-ss"));
            _logWriter = new StreamWriter(logFileName, append: true, Encoding.UTF8) { AutoFlush = true };
            log("INIT", "Logger initialized");
        }

        public static ILogger create()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        private string FormatLogEntry(string level, string message)
        {
            _logEntryNumber++;
            return string.Format("{0:000000}-{1:dd.MM.yyyy HH:mm:ss}-{2} {3}", _logEntryNumber, DateTime.Now, level, message);
        }

        private void log(string level, string message)
        {
            _logWriter.WriteLine(FormatLogEntry(level, message));
        }

        public void start(string title)
        {
            if (_disposed) throw new ObjectDisposedException("Logger");
            _namespaceLevel++;
            log("STRT", $"A{new string(':', _namespaceLevel)} {title}");
        }

        public void log(string message)
        {
            if (_disposed) throw new ObjectDisposedException("Logger");
            log("INFO", $"A{new string(':', _namespaceLevel)} {message}");
        }

        public void stop()
        {
            if (_disposed) throw new ObjectDisposedException("Logger");
            if (_namespaceLevel > 0)
            {
                log("STOP", $"A{new string(':', _namespaceLevel)}");
                _namespaceLevel--;
            }
            else
            {
                log("WARN", "Attempt to stop without a matching start.");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _logWriter?.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Logger()
        {
            Dispose(false);
        }
    }
}
