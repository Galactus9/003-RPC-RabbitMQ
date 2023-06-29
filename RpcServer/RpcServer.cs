using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RPC.Model;

namespace RpcServer
{
    // Rpc Client on Server

    // The RpcServer class handles communication with the RabbitMQ server and performs calculations based on received requests.
    public class RpcServer : IDisposable
    {
        // The name of the RabbitMQ queue used for receiving requests.
        private const string QueueName = "RpcQueue";
        private IConnection _connection;
        private IModel _channel;
        private bool _isDisposed;

        public RpcServer()
        {
            // Create a connection to the RabbitMQ server.
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declare the queue with the specified name.
            _channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            // Set the quality of service for message retrieval from the queue.
            _channel.BasicQos(0, 1, false);

            // Create a consumer to receive messages from the queue.
            var consumer = new EventingBasicConsumer(_channel);
            _channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);
            consumer.Received += Consumer_Received;
        }

        // Event handler for processing received messages.
        private void Consumer_Received(object? sender, BasicDeliverEventArgs ea)
        {
            LogMessage?.Invoke("Received Request from client..");

            // Extract the message body and deserialize it into a TestModel object.
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            TestModel? model = JsonConvert.DeserializeObject<TestModel>(message);

            // Prepare the response properties.
            var replyProps = _channel.CreateBasicProperties();
            replyProps.CorrelationId = ea.BasicProperties.CorrelationId;
            replyProps.ReplyTo = ea.BasicProperties.ReplyTo;

            // Perform the calculation based on the received model.
            var result = Calculator.Calculate(model);
            LogMessage?.Invoke($"Calculation result is {result}");

            // Serialize the response and publish it to the reply-to queue.
            var response = JsonConvert.SerializeObject(result);
            var responseBody = Encoding.UTF8.GetBytes(response);
            _channel.BasicPublish(exchange: "", routingKey: replyProps.ReplyTo, basicProperties: replyProps, body: responseBody);

            // Acknowledge the message processing.
            _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        }

        // Delegate for handling log messages.
        public delegate void LogMessageHandler(string message);

        // Event that is triggered when a log message needs to be emitted.
        public event LogMessageHandler LogMessage;

        // Clean up resources.
        private void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing)
            {
                _channel.Close();
            }
            _isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~RpcServer()
        {
            Dispose(false);
        }
    }
}