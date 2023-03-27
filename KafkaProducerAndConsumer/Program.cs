using Confluent.Kafka;
using KafkaProducerAndConsumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeatherProducer, WeatherProducer>();
builder.Services.AddSingleton<IProducer<int, WeatherForecast>>(
    provider =>
    {
        var config = new ProducerConfig()
        {
            BootstrapServers = "localhost:9092"
        };
        var producerBuilder = new ProducerBuilder<int, WeatherForecast>(config);
        
        return producerBuilder.Build();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();