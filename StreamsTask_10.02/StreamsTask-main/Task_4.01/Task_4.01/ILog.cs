using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._01
{
    public interface ILog
    {
        void Log(string message);
        void SaveLog();
        string GetLog();
    }
}
