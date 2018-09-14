using System;

namespace AddressAPI3.Common.Mail
{
    public class AppErrorMailService : IMailService
    {
        public void Send(string subject, string msg)
        {
            //Mandrill - Send email to apperrors@socialicity.co.uk

            throw new NotImplementedException();
        }
    }
}
