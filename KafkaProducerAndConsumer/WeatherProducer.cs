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
        throw new NotImplementedException();
    }
}