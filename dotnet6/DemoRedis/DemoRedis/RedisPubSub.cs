using StackExchange.Redis;

namespace DemoRedis
{
    /// <summary>
    /// redis发布订阅
    /// </summary>
    internal class RedisPubSub
    {
        private ConnectionMultiplexer ConnectionMultiplexer;
        public RedisPubSub()
        {
            ConnectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
        }

        /// <summary>
        /// 订阅
        /// </summary>
        public void Sub(string messageTopic, Action<ChannelMessage> action)
        {
            // 订阅器
            var subscriber = ConnectionMultiplexer.GetSubscriber();

            // 订阅消息
            var messageQueue = subscriber.Subscribe(messageTopic);

            //// 处理消息
            //messageQueue.OnMessage((message) =>
            //{
            //    // 消息内容
            //    var messageContent = message.Message;


            //});

            messageQueue.OnMessage(action);

        }

        /// <summary>
        /// 发布者
        /// </summary>
        public void Pub(string messageTopic, string message)
        {
            // 订阅器
            var subscriber = ConnectionMultiplexer.GetSubscriber();

            // 发布消息
            subscriber.Publish(messageTopic, message);
        }
    }
}
