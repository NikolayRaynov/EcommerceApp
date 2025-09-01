using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace EcommerceApp.Services.Data
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;

        public EmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var senderEmail = configuration["EmailSettings:SenderEmail"];
            var smtpUsername = configuration["EmailSettings:SmtpUsername"];
            var smtpPassword = configuration["EmailSettings:SmtpPassword"];

            var emailToSend = new MimeMessage();

            emailToSend.From.Add(MailboxAddress.Parse(senderEmail));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;

            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = htmlMessage
            };

            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                await emailClient.ConnectAsync("smtp.gmail.com", 587, MailKit
                    .Security.SecureSocketOptions.StartTls);
                await emailClient.AuthenticateAsync(smtpUsername, smtpPassword);
                await emailClient.SendAsync(emailToSend);
                await emailClient.DisconnectAsync(true);
            }
        }
    }
}
