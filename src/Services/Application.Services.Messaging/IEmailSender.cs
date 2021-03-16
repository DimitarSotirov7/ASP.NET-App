namespace Application.Services.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task<string> SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            IEnumerable<EmailAttachment> attachments = null);
    }
}
