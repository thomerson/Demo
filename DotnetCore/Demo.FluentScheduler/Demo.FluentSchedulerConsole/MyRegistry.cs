using Demo.FluentSchedulerConsole.Job;
using FluentScheduler;
using Gatlin.Utils.Standard.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.FluentSchedulerConsole
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            // 默认情况下，该库允许计划与先前触发的同一计划的执行并行运行,禁止同一任务并发执行，
            // 等待上一个任务执行完再执行下一个任务
            // 或者用NonReentrant单个job设置
            NonReentrantAsDefault();

            // Schedule an IJob to run at an interval
            //Schedule<MyJob>()
            //    //.NonReentrant()
            //    .ToRunNow().AndEvery(2).Seconds();

            // Schedule an IJob to run once, delayed by a specific time interval
            // 只执行1次
            //Schedule<MyJob>().ToRunOnceIn(5).Seconds();

            //// Schedule a simple job to run at a specific time
            //// 每天21:15
            //Schedule(() => Logger.Write("It's 9:15 PM now.")).ToRunEvery(1).Days().At(21, 15);

            //// Schedule a more complex action to run immediately and on an monthly interval
            //// 每月一次
            //Schedule<MyComplexJob>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(3, 0);

            //// Schedule a job using a factory method and pass parameters to the constructor.
            //// 10秒每次
            //Schedule(() => new MyComplexJob("Foo", DateTime.Now)).ToRunNow().AndEvery(10).Seconds();

            //// Schedule multiple jobs to be run in a single schedule
            //// 现在开始5分钟每次
            Schedule<MyJob>().AndThen<MyOtherJob>().ToRunNow().AndEvery(5).Minutes();

            // 现在开始  然后每周一次
            Schedule<MyJob>().ToRunEvery(0).Weeks().On(DayOfWeek.Monday).At(14, 0);

            // Every "one" weeks
            //Schedule<MyJob>().ToRunEvery(1).Weeks().On(DayOfWeek.Monday).At(14, 0);
        }
    }
}
