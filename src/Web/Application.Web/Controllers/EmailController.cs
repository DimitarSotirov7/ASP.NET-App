namespace Application.Web.Controllers
{
    using System.Threading.Tasks;

    using Application.Services.Messaging;
    using Application.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class EmailController : BaseController
    {
        private readonly IEmailSender emailSender;
        private readonly IConfiguration configuration;

        public EmailController(IEmailSender emailSender, IConfiguration configuration)
        {
            this.emailSender = emailSender;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Send(EmailInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("~/Views/Home/Contact.cshtml", input);
            }

            // SendGrid doesn't allowed emails from unregistered email addresses.
            string fromEmail = this.configuration["SendGrid:FromEmail"];
            string fromName = input.FromName ?? this.configuration["App:Name"];
            string toEmail = this.configuration["SendGrid:ToEmail"];
            string subject = input.Subject;
            string content = input.Message;

            string statusCode = await this.emailSender
                    .SendEmailAsync(fromEmail, fromName, toEmail, subject, content);

            if (statusCode.ToLower().Contains("accepted"))
            {
                this.TempData["emailMessage"] = "Your message has been sent successfully";
            }

            return this.Redirect("/");
        }
    }
}
