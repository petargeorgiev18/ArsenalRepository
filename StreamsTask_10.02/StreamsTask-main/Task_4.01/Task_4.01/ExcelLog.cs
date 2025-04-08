using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._01
{
    public class ExcelLogger:ILog
    {
        private string filePath;
        private StringBuilder builder;
        public ExcelLogger(string path)
        {
            filePath = path;
            builder = new StringBuilder();
        }
        public string GetLog()
        {
           return builder.ToString();
        }
        public void Log(string message)
        {
            builder.AppendLine(message);
        }
        public void SaveLog()
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.AddWorksheet("TeamHistory");
                    var logEntries = builder.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                    for (int i = 0; i < logEntries.Length; i++)
                    {
                        var content = logEntries[i];
                        worksheet.Cell(i + 2, 1).Value = content;
                    }
                    workbook.SaveAs(filePath);
                }
                Console.WriteLine("Log saved to Excel file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving log to Excel: {ex.Message}");
            }
        }
    }
}
