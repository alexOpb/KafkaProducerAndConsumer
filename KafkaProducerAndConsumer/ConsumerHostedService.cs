using Confluent.Kafka;

namespace KafkaProducerAndConsumer;

public class ConsumerHostedService : BackgroundService
{
    private readonly IConsumer<int, WeatherForecast> _consumer;
    private readonly ILogger<ConsumerHostedService> _logger;

    public ConsumerHostedService(IConsumer<int, WeatherForecast> consumer, ILogger<ConsumerHostedService> logger)
    {
        _consumer = consumer;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe("topic_name_place_holder");
        
        await Task.Yield();
        
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = _consumer.Consume(stoppingToken);
            _logger.LogInformation("MessageId = {Id}, Value {Value}", message.Message.Key, message.Message.Value);
            _consumer.Commit();
        }

        _consumer.Unsubscribe();
    }

}