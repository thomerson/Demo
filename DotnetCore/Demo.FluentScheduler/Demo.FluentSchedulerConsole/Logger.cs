using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.FluentSchedulerConsole
{
    public class Logger
    {
        public static void Write(string content)
        {
            Console.WriteLine($"{DateTime.Now}:{content}");
        }
    }
}
