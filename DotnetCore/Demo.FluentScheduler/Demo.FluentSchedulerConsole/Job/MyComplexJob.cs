using FluentScheduler;
using Gatlin.Utils.Standard.Log;

namespace Demo.FluentSchedulerConsole.Job
{
    public class MyComplexJob : IJob
    {
        public MyComplexJob(string name, System.DateTime time)
        {
            this.Name = name;
        }

        private string Name;
        public void Execute()
        {
            Logger.Write($"{nameof(MyComplexJob)}:{this.Name},{System.DateTime.Now.ToString("yyyy-MM-dd HHmmss")}");
        }
    }
}
