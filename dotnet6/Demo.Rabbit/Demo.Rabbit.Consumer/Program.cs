﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Demo.Rabbit.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consumer started!");
            SubscribeMQ();
            Console.ReadLine();
        }

        static void SubscribeMQ()
        {
            var factory = new ConnectionFactory()       // 创建连接工厂对象
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            var connection = factory.CreateConnection();    // 创建连接对象
            var channel = connection.CreateModel();         // 创建连接会话对象

            var queueName = "queue1";

            //声明一个队列
            channel.QueueDeclare(
              queue: queueName,//消息队列名称
              durable: false,//是否持久化,true持久化,队列会保存磁盘,服务器重启时可以保证不丢失相关信息。
              exclusive: false,//是否排他,true排他的,如果一个队列声明为排他队列,该队列仅对首次声明它的连接可见,并在连接断开时自动删除.
              autoDelete: false,//是否自动删除。true是自动删除。自动删除的前提是：致少有一个消费者连接到这个队列，之后所有与这个队列连接的消费者都断开时,才会自动删除.
              arguments: null ////设置队列的一些其它参数
            );

            #region exchange
            var exchangeName = "exchange";
            var routeKey = "key";
            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);  //申明交换机
            //channel.QueueBind(queueName, exchangeName, "");  //exchangeName
            channel.QueueBind(queueName, exchangeName, routeKey);  //exchangeName
            #endregion

            // 创建消费者对象
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {

                byte[] message = ea.Body.ToArray();
                Console.WriteLine("接收到的消息为：" + Encoding.UTF8.GetString(message));

                channel.BasicAck(ea.DeliveryTag, true); // 开启返回消息确认 手动模式
            };

            // 消费者开启监听
            channel.BasicConsume(queueName, true, consumer);

            Console.ReadKey();
            channel.Dispose();
            connection.Close();

        }
    }
}