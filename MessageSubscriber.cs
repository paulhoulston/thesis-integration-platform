using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace thesis_integration_platform;

class MessageSubscriber<T> : IAsyncDisposable
{
    readonly ServiceBusClient _serviceBusClient = new ServiceBusClient(Configuration.ServiceBusConnectionString);
    readonly ServiceBusProcessor _messageProcessor;

    public MessageSubscriber(Func<T, Task> onProcessMessage, Func<Exception, Task> onError)
    {
        _messageProcessor = _serviceBusClient.CreateProcessor(Configuration.TopicName, Configuration.Subscription);
        _messageProcessor.ProcessErrorAsync += async (args) => await onError(args.Exception);
        _messageProcessor.ProcessMessageAsync += async (args) =>
        {
            await onProcessMessage(DeserializeMessage(args.Message.Body));
            await args.CompleteMessageAsync(args.Message);
        };
        _messageProcessor.StartProcessingAsync();
    }

    static T DeserializeMessage(BinaryData body) => JsonConvert.DeserializeObject<T>(body.ToString());

    public async ValueTask DisposeAsync()
    {
        await _messageProcessor.StopProcessingAsync();
        await _serviceBusClient.DisposeAsync();
    }
}
