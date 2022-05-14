using DotnetRemoting.RemotingObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace DotnetRemoting.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //使用TCP通道连接
                var channel = new TcpClientChannel();
                ChannelServices.RegisterChannel(channel, true);
                //获取远程对象
                DemoObject demo = (DemoObject)Activator.GetObject(typeof(DemoObject), "tcp://localhost:8899/DemoObject");
                //调用远程对象的方法
                var id = demo.Add(new RemotingObject.model.BaseModel() { Id = 1 });

                demo.Delete(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
