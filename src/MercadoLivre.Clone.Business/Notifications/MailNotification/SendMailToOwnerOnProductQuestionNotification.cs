using MediatR;
using MercadoLivre.Clone.Business.Events;

namespace MercadoLivre.Clone.Business.Notifications.MailNotification
{
    public class SendMailToOwnerOnProductQuestionNotification : INotificationHandler<ProductQuestionEvent>
    {
        public Task Handle(ProductQuestionEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Enviando email para: {0} com o assunto {1}", notification.MailTo, notification.MailSubject);

            return Task.CompletedTask;
        }
    }
}
