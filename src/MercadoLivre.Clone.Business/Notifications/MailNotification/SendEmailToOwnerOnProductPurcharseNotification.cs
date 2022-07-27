using MediatR;
using MercadoLivre.Clone.Business.Events;

namespace MercadoLivre.Clone.Business.Notifications.MailNotification
{
    public class SendEmailToOwnerOnProductPurcharseNotification : INotificationHandler<ProductPurchaseEvent>
    {
        public Task Handle(ProductPurchaseEvent notification, CancellationToken cancellationToken)
        {
            var productOnerName = notification.Product.Owner.UserName;
            var productConsumerName = notification.Consumer.UserName;
            var productName = notification.Product.Name;

            Console.WriteLine($"Olá {productOnerName}.\n{productConsumerName} realizou a compra do seguinte produto: {productName}");

            return Task.CompletedTask;
        }
    }
}
