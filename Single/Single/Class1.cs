using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single
{
    public class Logger
    {
        private static Logger _instance = null;
        private static readonly object _lock = new object();
        private readonly string _logFilePath;

        private Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public static Logger GetInstance(string logFilePath)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger(logFilePath);
                    }
                }
            }

            return _instance;
        }

        public void Log(string message)
        {
            using (StreamWriter writer = File.AppendText(_logFilePath))
            {
                writer.WriteLine(message);
            }
        }
    }
}
