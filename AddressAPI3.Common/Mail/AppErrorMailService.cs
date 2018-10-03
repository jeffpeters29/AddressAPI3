using Mandrill;
using Mandrill.Models;
using Mandrill.Requests.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressAPI3.Common.Mail
{
    public class AppErrorMailService : IMailService
    {
        private readonly string _mailTo;
        private readonly string _mailFrom;

        public AppErrorMailService(string mailTo, string mailFrom)
        {
            _mailTo = mailTo;
            _mailFrom = mailFrom;
        }

        public async Task<bool> Send(string subject, string emailBody)
        {
            var emailAddresses = new List<EmailAddress>();

            if (!string.IsNullOrEmpty(_mailTo) && !string.IsNullOrEmpty(_mailFrom) && !string.IsNullOrEmpty(subject) && !string.IsNullOrEmpty(emailBody))
            {
                var emailAddress = new EmailAddress
                {
                    Name = "AppErrors",
                    Email = _mailTo
                };
                emailAddresses.Add(emailAddress);

                var emailMessage = new EmailMessage
                {
                    FromEmail = _mailFrom,
                    FromName = "Application Error",
                    To = emailAddresses,
                    Subject = subject,
                    Html = emailBody
                };

                var api = new MandrillApi("TftugCc2xFIYj3Kv21uZhQ");
                var results = await api.SendMessage(new SendMessageRequest(emailMessage));

                var res = results.All(r => r.Status.Equals(EmailResultStatus.Queued) || r.Status.Equals(EmailResultStatus.Sent));

                return results.All(r => r.Status.Equals(EmailResultStatus.Queued) || r.Status.Equals(EmailResultStatus.Sent));
            }

            return false;
        }
    }
}
