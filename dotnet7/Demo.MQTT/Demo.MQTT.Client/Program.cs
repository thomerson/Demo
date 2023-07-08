// See https://aka.ms/new-console-template for more information
using MQTTnet.Client;
using MQTTnet;
using System.Text;

await MQTTClientTest();

Console.WriteLine("Hello, World!");

Console.ReadLine();


static async Task MQTTClientTest()
{
    var factory = new MqttFactory();
    var client = factory.CreateMqttClient();
    var options = new MqttClientOptionsBuilder()
        .WithTcpServer("localhost", 1883)
        .WithCredentials("lotClient", "lotClient")
        .Build();
    client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;
    await client.ConnectAsync(options);
    await client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("testTopic").Build());
}

static Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
{
    Console.WriteLine($"接收的消息: {arg.ApplicationMessage.ConvertPayloadToString()}");
    return Task.CompletedTask;
}