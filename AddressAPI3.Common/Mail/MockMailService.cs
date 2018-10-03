using System.Diagnostics;
using System.Threading.Tasks;

namespace AddressAPI3.Common.Mail
{
    public class MockMailService : IMailService
    {
        private readonly string _mailTo;

        public MockMailService(string mailTo)
        {
            _mailTo = mailTo;
        }

        public async Task<bool> Send(string subject, string emailBody)
        {
            Debug.WriteLine($"Mail to : {_mailTo}");
            Debug.WriteLine($"Subject : {subject}");
            Debug.WriteLine($"Body : {emailBody}");

            return true;
        }
    }
}
