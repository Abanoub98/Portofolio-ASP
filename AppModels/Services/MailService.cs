
using System.Threading.Tasks;
using Portofolio.Models;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
namespace Portofolio.AppModels.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }
    }
}