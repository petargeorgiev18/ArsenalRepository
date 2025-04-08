using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._01
{
    public class TextLog:ILog
    {
        private StringBuilder logContent;
        private string filepath;
        public TextLog(string filepath)
        {
            logContent = new StringBuilder();
            this.filepath = filepath;
        }
        public void Log(string message)
        {
            logContent.AppendLine(message);
        }
        public void SaveLog()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(this.filepath))
                {
                    foreach (var content in logContent.ToString())
                    {
                        writer.Write(content);
                    }
                }
                Console.WriteLine($"Log saved to {this.filepath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving log: {ex.Message}");
            }
        }
        public string GetLog()
        {
            return logContent.ToString();
        }
    }
}
