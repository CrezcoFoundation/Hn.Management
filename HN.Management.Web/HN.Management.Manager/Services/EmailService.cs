using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace HN.Management.Manager.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _emailOptions;

        public EmailService(IOptions<EmailOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }
        
        public async Task<string> ContactMe(ContactRequest contactRequest)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_emailOptions.From);

                mailMessage = this.BuildRecipient(mailMessage, _emailOptions.To, _emailOptions.Cc);
                mailMessage.Subject = $"New Contact Received - {contactRequest.Name}";
                mailMessage.Body = $"Dear Crezco Information Team,\r\nThere has been a new inquiry on the website. See the contact information below: \r\nName: {contactRequest.Name}, \r\nEmailAddress: {contactRequest.Email}, \r\nMessage: {contactRequest.Message}";

                var smtpClient = await this.GetSmtpClient();
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error: " + ex.Message);
            }

            return await Task.FromResult("Email Sent Successfully.");
        }

        public async Task<string> SendNewsletterProgram(string email)
        {
            var smtpClient = await this.GetSmtpClient();

            var mailMessage = new MailMessage()
            {
                Subject = $"Newsletter Program Request Received - {email}",
                From = new MailAddress(_emailOptions.From),
                Body = $"Dear Crezco Onboarding Team,\r\nI want to receive Newsletter Program, this is my email: {email}"
            };

            mailMessage = this.BuildRecipient(mailMessage, _emailOptions.To, _emailOptions.Cc);
            smtpClient.Send(mailMessage);

            return await Task.FromResult("Email Sent Sucessfully.");
        }

        private async Task<SmtpClient> GetSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = _emailOptions.Server;
            smtpClient.Port = _emailOptions.Port;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_emailOptions.AdminEmail, _emailOptions.CredentialPassword);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = _emailOptions.Timeout;

            return await Task.FromResult(smtpClient);
        }

        private MailMessage BuildRecipient(MailMessage mailMessage, string to, string cc)
        {
            var emailRecipients = to.Split(",").ToList();

            foreach (var mails in emailRecipients)
            {
                mailMessage.To.Add(mails);
            }

            var emailCcRecipients = cc.Split(",").ToList();
            foreach (var mails in emailCcRecipients)
            {
                mailMessage.CC.Add(mails);
            }

            return mailMessage;
        }
    }
}

