using System;
using System.Collections.Generic;
using System.Text;

namespace AddressAPI3.Common.Security
{
    public interface IPasswordHashService
    {
        string HashPassword(string password);
    }
}
