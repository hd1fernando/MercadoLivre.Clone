using MediatR;

namespace MercadoLivre.Clone.Business.Events
{
    public class ProductQuestionEvent : INotification
    {
        public string? MailTo { get; }
        public string? MailSubject { get; }

        public ProductQuestionEvent(string? mailTo, string? mailSubject)
        {
            MailTo = mailTo;
            MailSubject = mailSubject;
        }
    }
}
