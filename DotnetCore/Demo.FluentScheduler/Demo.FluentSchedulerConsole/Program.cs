using FluentScheduler;
//using Gatlin.Utils.Standard.Log;
using System;
using System.Threading;

namespace Demo.FluentSchedulerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ListenForStart();
            ListenForEnd();
            ListenForException();
            Initialize();
            Sleep();
            Console.WriteLine("Hello World!");
        }


        private static void ListenForStart()
        {
            // 每个job每次启动都会触发
            JobManager.JobStart += (info) => Logger.Write($"{info.Name}: started");
        }


        private static void ListenForEnd()
        {
            JobManager.JobEnd += (info) => Logger.Write(
                info.Duration > TimeSpan.FromSeconds(1) ?
                $"{info.Name}: ended ({info.Duration})" :
                $"{info.Name}: ended"
            );
        }

        private static void ListenForException()
        {
            JobManager.JobException += info =>
                Logger.Write($"{info.Name}: {Environment.NewLine}{info.Exception}");
        }

        private static void Initialize()
        {
            JobManager.Initialize(new MyRegistry());
            JobManager.RemoveJob("Removed");

            JobManager.AddJob(
                () => Logger.Write("Late: added after the initialize"),
                s => s.WithName("Late").ToRunNow()
            );

            // 要停止并等待正在运行的作业完成
            //JobManager.StopAndBlock();
        }

        private static void Sleep()
        {
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
