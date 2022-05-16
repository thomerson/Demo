using FluentScheduler;
using Gatlin.Utils.Standard.Log;

namespace Demo.FluentSchedulerWebSite.Job
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
