using SimpleLogger;
using System;
using System.IO;

namespace VTOLVR_MissionAssistant.Services
{
    public class Logger : SimpleLogger.Logger
    {
        #region Events

        public event EventHandler LogWriteError;

        #endregion

        #region Methods

        protected override void WriteToLogFile(LogLevel level, string message)
        {
            EnsureLogFile();

            try
            {
                FileStream fs = null;

                if (RollLogFile())
                {
                    fs = new FileStream(LogFile, FileMode.Truncate, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(LogFile, FileMode.Append, FileAccess.Write);
                }

                StreamWriter writer = new StreamWriter(fs);

                string date = DateTime.Now.ToString("MM/dd/yyyy-hh:mm:ss");

                writer.WriteLine($"{date}|{level}|{message}");

                writer.Close();
                fs.Close();

                writer.Dispose();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unable to write to the log file.{Environment.NewLine}{ex}");

                LogWriteError?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
