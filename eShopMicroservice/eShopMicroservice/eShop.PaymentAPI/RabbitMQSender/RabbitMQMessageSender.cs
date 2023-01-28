using eShop.MessageBus;
using eShop.PaymentAPI.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace eShop.PaymentAPI.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _userName;
        private readonly string _password;
        private IConnection _connection;
        private const string ExchangeName = "FanoutPaymentUpdateExchange";

        public RabbitMQMessageSender()
        {
            _hostName = "127.0.0.1";
            _userName = "dnr";
            _password = "dnr123";
        }

        public void SendMessage(BaseMessage message)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();
                channel.ExchangeDeclare(exchange: ExchangeName, ExchangeType.Fanout, durable: false);
                byte[] body = GetMessageAsByteArray(message);
                channel.BasicPublish(exchange: ExchangeName, routingKey: "", basicProperties: null, body: body);
            }
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize<UpdatePaymentResultMessage>((UpdatePaymentResultMessage)message, options);
            var body = Encoding.UTF8.GetBytes(json);

            return body;
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
                return true;

            CreationConnection();

            return _connection != null;
        }

        private void CreationConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                throw new Exception("Connection RabbitMQ error", ex.InnerException);
            }
        }
    }
}
