using System.Text;
using RabbitMQ.Client;

namespace MessageQueuer
{
    public class Manager
    {
        public void Sender(string hostName, string queue, string message)
        {
            var factory = new ConnectionFactory { HostName = hostName };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: body);
                }
            }
        }
    }
}
