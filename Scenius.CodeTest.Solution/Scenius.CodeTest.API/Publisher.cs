using RabbitMQ.Client;
using System.Text;

namespace Scenius.CodeTest.API
{
    public class Publisher
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

        private const string QUEUE = "Calculator";

        public Publisher(IConfiguration configuration)
        {
            _factory = new() { HostName = configuration.GetValue<string>("AMQP") };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(QUEUE, true, false, false, null);
        }

        public void Publish(string message)
        {
            byte[] body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(string.Empty, QUEUE, null, body);
        }
    }
}
