using FluentScheduler;
using Gatlin.Utils.Standard.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.FluentSchedulerConsole.Job
{
    class MyOtherJob : IJob
    {
        public void Execute()
        {
            Logger.Write($"{nameof(MyOtherJob)}:{System.DateTime.Now.ToString("yyyy-MM-dd HHmmss")}");
        }
    }
}
