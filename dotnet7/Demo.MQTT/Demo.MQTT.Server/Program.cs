// See https://aka.ms/new-console-template for more information
using MQTTnet.Client;
using MQTTnet;
using System.Text;

await MQTTP();

Console.WriteLine("Hello, World!");



static async Task MQTTP()
{
    var factory = new MqttFactory();
    var client = factory.CreateMqttClient();

    var options = new MqttClientOptionsBuilder()
        .WithTcpServer("localhost", 1883)
        .WithCredentials("lotServer", "lotServer")
        .Build();

    await client.ConnectAsync(options);
    while (true)
    {
        Console.WriteLine("输入要发布的信息: ");
        var message = Console.ReadLine();

        var mqttMessage = new MqttApplicationMessageBuilder()
            .WithTopic("testTopic")
            .WithPayload(Encoding.UTF8.GetBytes(message))
            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
            .Build();

        await client.PublishAsync(mqttMessage);
    }
}