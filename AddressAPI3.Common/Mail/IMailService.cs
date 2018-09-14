using System;
using System.Collections.Generic;
using System.Text;

namespace AddressAPI3.Common.Mail
{
    public interface IMailService
    {
        void Send(string subject, string msg);
    }
}
