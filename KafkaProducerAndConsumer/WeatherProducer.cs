using Confluent.Kafka;

namespace KafkaProducerAndConsumer;

public class WeatherProducer : IWeatherProducer
{
    private readonly IProducer<int, WeatherForecast> _producer;

    public WeatherProducer(IProducer<int, WeatherForecast> producer)
    {
        _producer = producer;
    }
    public void Publish(WeatherForecast weatherForecast)
    {
        var message = new Message<int, WeatherForecast>
        {
            Key = weatherForecast.Id,
            Value = weatherForecast
        };

        _producer.Produce("topic_name_place_holder", message);
    }
}