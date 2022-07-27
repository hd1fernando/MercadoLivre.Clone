using MediatR;

namespace MercadoLivre.Clone.Business.Events
{

    public class ProductQuestionEvent : INotification
    {
        public string? MailTo { get; }
        public string? MailSubject { get; }
        public string? ProductId { get; }

        public ProductQuestionEvent(string? mailTo, string? mailSubject, string? productId)
        {
            MailTo = mailTo;
            MailSubject = mailSubject;
            ProductId = productId;
        }
    }
}
