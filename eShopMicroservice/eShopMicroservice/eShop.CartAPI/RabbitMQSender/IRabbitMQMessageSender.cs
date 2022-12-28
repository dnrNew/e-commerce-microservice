using eShop.MessageBus;

namespace eShop.CartAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage message, string queueName);
    }
}
