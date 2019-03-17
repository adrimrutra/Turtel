using System;
using System.Text;
using System.IO;
using System.Configuration;

namespace TurtleLogger
{
    public class Logger : ILog
    {
        private readonly string datetimeFormat;
        private readonly string fileName;

        /// <summary>
        /// Initiate an instance of Logger class.
        /// If log file does not exist, it will be created automatically.
        /// </summary>

        public Logger()
        {
            datetimeFormat = ConfigurationManager.AppSettings["datetimeFormat"];
            fileName = ConfigurationManager.AppSettings["fileName"];

            if (!File.Exists(fileName))
            {
                string header = String.Format("{0} {1} - file has been created.", DateTime.Now.ToString(datetimeFormat), fileName);
                WriteLine(header, false);
            }
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            WriteFormattedLog(LogLevel.ERROR, text);
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            WriteFormattedLog(LogLevel.INFO, text);
        }

        private void WriteLine(string text, bool append = true)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, append, Encoding.UTF8))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        writer.WriteLine(text);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void WriteFormattedLog(LogLevel level, string text)
        {
            StringBuilder st = new StringBuilder(DateTime.Now.ToString(datetimeFormat));
            switch (level)
            {
                case LogLevel.INFO:
                    st.Append(" [INFO]   ");
                    break;
                case LogLevel.ERROR:
                    st.Append(" [ERROR]   ");
                    break;
            }
            WriteLine(st.Append(text).ToString());
        }
    }
}
