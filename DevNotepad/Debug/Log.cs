using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Config;

namespace DevNotepad.Debug
{
    /// <summary>
    /// Very simple logging class. This should be converted to a more robust logging system
    /// such as log4net in the future but this works for now.
    /// </summary>
    public static class Log
    {
        private static Object _LockObj = new Object();
        private static StreamWriter _FileStream = null;
        private static string FilePath = Path.Combine(Paths.LogPath, String.Format("logging_{0}.txt", DateTime.UtcNow.ToString("yyyy-MM-dd")));
        public static void Write(Exception ex)
        {
            Write(ex.ToString());
        }

        public static void Write(string Message)
        {
            lock (_LockObj)
            {
                if (Message.IndexOf('\n') > -1)
                {
                    string lineBreak = new String('-', 80);
                    _FileStream.WriteLine(lineBreak);
                    _FileStream.WriteLine(DateTime.UtcNow.ToString());
                    _FileStream.WriteLine(lineBreak);
                }
                else
                {
                    _FileStream.Write(String.Format("{0}: ", DateTime.UtcNow.ToString()));
                }
                _FileStream.WriteLine(Message);
            }
        }

        public static void Initialize()
        {
            try
            {
                _FileStream = new StreamWriter(File.OpenWrite(FilePath));
            }
            catch (Exception ex)
            {
                // No way to write this to a log since creating the log file failed so just
                // show a messagebox.
                MessageBox.Show(ex.ToString());
            }
        }

        public static void Finalize()
        {
            _FileStream.Dispose();
        }

    }
}
