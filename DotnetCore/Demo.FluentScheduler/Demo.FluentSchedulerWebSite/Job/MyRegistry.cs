using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.FluentSchedulerWebSite.Job
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            //不允许重复执行（意思就是每一次任务都必须执行完成后，才能开启下一次执行，防止并发执行带来的问题。）
            NonReentrantAsDefault();

            Schedule<MyJob>().ToRunEvery(1).Minutes(); 
        }
    }
}
