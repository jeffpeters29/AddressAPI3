using System.Diagnostics;

namespace AddressAPI3.Common.Mail
{
    public class MockMailService : IMailService
    {
        private readonly string _mailTo;

        public MockMailService(string mailTo)
        {
            _mailTo = mailTo;
        }

        public void Send(string subject, string msg)
        {
            Debug.WriteLine($"Mail to : {_mailTo}");
            Debug.WriteLine($"Subject : {subject}");
            Debug.WriteLine($"Message : {msg}");
        }
    }
}
