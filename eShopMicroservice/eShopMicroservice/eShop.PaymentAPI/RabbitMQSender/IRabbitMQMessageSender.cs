using eShop.MessageBus;

namespace eShop.PaymentAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage message);
    }
}
