using MediatR;
using MercadoLivre.Clone.Business.Events;

namespace MercadoLivre.Clone.Business.Notifications.MailNotification
{
    public class SendMailToOwnerOnProductQuestionNotification : INotificationHandler<ProductQuestionEvent>
    {
        public Task Handle(ProductQuestionEvent notification, CancellationToken cancellationToken)
        {
            var productLink = $"https://localhost:7234/api/Product/{notification.ProductId}";
            Console.WriteLine("Enviando email para: {0} com o assunto {1}\n {2}", notification.MailTo, notification.MailSubject, productLink);

            return Task.CompletedTask;
        }
    }
}
