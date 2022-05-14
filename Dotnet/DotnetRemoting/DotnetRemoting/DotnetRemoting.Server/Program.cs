using DotnetRemoting.RemotingObject;
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace DotnetRemoting.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //利用TCP通道，并侦听8899端口
            var channel = new TcpServerChannel(8899);
            ChannelServices.RegisterChannel(channel, true);
            //使用WellKnown激活方式，并且使用SingleCall模式
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(DemoObject), nameof(DemoObject), WellKnownObjectMode.SingleCall);
            Console.Read();
        }
    }
}
