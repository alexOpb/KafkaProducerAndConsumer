using System.Text;
using System.Text.Json;
using Confluent.Kafka;

namespace KafkaProducerAndConsumer;

public class JsonSerializer<IMessage>: ISerializer<IMessage>
{
    public byte[] Serialize(IMessage data, SerializationContext context)
    {
        return data switch
        {
            string => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)),
            _ => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data))
        };
    }
}