using Microsoft.Extensions.Configuration;
using SiparisUygulama.Contract.DataContract.Model;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace SiparisUygulama.Business
{
    public interface IEmailService
    {
        void SendEmail(string recipientEmail, string subject, string body);
    }
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings").Get<SmtpSettings>();

                var smtpClient = new SmtpClient(smtpSettings.Server)
                {
                    Port = smtpSettings.Port,
                    Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password),
                    EnableSsl = smtpSettings.EnableSsl,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings.SenderEmail, smtpSettings.SenderName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(recipientEmail);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {

                throw new Exception("E-posta gönderme işlemi sırasında bir hata oluştu.", ex);
            }

        }
    }
}
