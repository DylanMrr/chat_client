using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ClientChat_1.Managers
{
    public class LogWriter
    {
        private string path = string.Empty;
        public LogWriter(string logMessage)
        {
            LogWrite(logMessage);
        }
        public void LogWrite(string logMessage)
        {
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //path = @"C:\Projects\Xamarin\chat_client\log.txt";
            //try
            {
                //using (StreamWriter w = new StreamWriter(new FileStream(path, FileMode.Append, FileAccess.Write)))
                using (StreamWriter w = File.AppendText(path + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            //catch (Exception ex)
            {
            }
        }

        private void Log(string logMessage, StreamWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
