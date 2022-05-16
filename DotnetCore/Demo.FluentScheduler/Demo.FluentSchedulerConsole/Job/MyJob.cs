using FluentScheduler;
using Gatlin.Utils.Standard.Log;
using System.Threading;

namespace Demo.FluentSchedulerConsole.Job
{
    public class MyJob : IJob
    {
        public void Execute()
        {
            //Thread.Sleep(5000);
            Logger.Write($"{nameof(MyJob)}:{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm：ss")}");
        }
    }
}
