using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Scenius.CodeTest.Data;
using Scenius.CodeTest.Shared;
using System.Text;

const string QUEUE = "Calculator";
const string HOST_NAME = "localhost";
const string DB_CONNECTION_STRING = "Host=localhost;Database=CalculatorDB;Username=postgres;Password=guest";
var factory = new ConnectionFactory { HostName = HOST_NAME };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

var dbOptionsBuilder = new DbContextOptionsBuilder<CalculatorDbContext>();
dbOptionsBuilder.UseNpgsql(DB_CONNECTION_STRING);

using var dbContext = new CalculatorDbContext(dbOptionsBuilder.Options);

channel.QueueDeclare(queue: QUEUE,
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += async (sender, args) =>
{
    var body = args.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);
    CalculationResult result = DoCalculation(message);
    dbContext.CalculationResults.Add(result);
    await dbContext.SaveChangesAsync();

    channel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
};

static CalculationResult DoCalculation(string message)
{
    Random rand = new();
    double result = rand.NextDouble();

    return new()
    {
        RawCalculation = message,
        Result = result
    };
}

channel.BasicConsume(QUEUE, false, consumer);

// Prevent application from exiting
Console.WriteLine("Press any key to exit");
Console.ReadLine();