using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Movies_Gallery.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        private SmtpClient _smtp;
        private MailMessage mail;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,IConfiguration config)
        {
            Options = optionsAccessor.Value;
            _config = config;
        }

        public AuthMessageSenderOptions Options { get; }
        
        public Task SendEmailAsync(string email, string subject, string message)
        {
            Options.SendGridKey = _config["Movies:ServiceApiKey"];
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("testowy.doprojektu321@gmail.com", "hjyqzyifhsxhrxvv"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
