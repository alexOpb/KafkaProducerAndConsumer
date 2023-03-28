namespace KafkaProducerAndConsumer;

public interface IWeatherProducer
{
    void Publish(WeatherForecast weatherForecast);
}