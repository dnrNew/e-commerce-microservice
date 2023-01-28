using eShop.PaymentProcessor;
using eShop.PaymentAPI.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using eShop.PaymentAPI.RabbitMQSender;

namespace eShop.PaymentAPI.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IProcessPayment _processPayment;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public RabbitMQPaymentConsumer(IConnection connection, IModel channel, IProcessPayment processPayment)
        {
            _connection = connection;
            _channel = channel;
            _processPayment = processPayment;
        }

        public RabbitMQPaymentConsumer(IProcessPayment processPayment, IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _processPayment = processPayment;
            _rabbitMQMessageSender = rabbitMQMessageSender;

            var factory = new ConnectionFactory
            {
                HostName = "127.0.0.1",
                UserName = "dnr",
                Password = "dnr123"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "orderpaymentprocessqueue", false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (channel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                PaymentMessage vo = JsonSerializer.Deserialize<PaymentMessage>(content);
                ProcessPayment(vo).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("orderpaymentprocessqueue", false, consumer);

            return Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentMessage vo)
        {
            var result = _processPayment.PaymentProcessor();

            UpdatePaymentResultMessage paymentResultMessage = new()
            {
                Status = result,
                OrderId = vo.OrderId,
                Email = vo.Email
            };

            try
            {
                _rabbitMQMessageSender.SendMessage(paymentResultMessage, "orderpaymentresultqueue");
            }
            catch (Exception ex)
            {
                throw new Exception("Error sender payment RabbitMQ queue", ex.InnerException);
            }
        }
    }
}
