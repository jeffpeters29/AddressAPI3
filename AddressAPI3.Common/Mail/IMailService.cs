using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AddressAPI3.Common.Mail
{
    public interface IMailService
    {
        Task<bool> Send(string subject, string emailBody);
    }
}
