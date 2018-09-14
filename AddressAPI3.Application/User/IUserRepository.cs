using System.Collections.Generic;

namespace AddressAPI3.Application.User
{
    using Domain;

    public interface IUserRepository
    {
        User GetUser(string username, string password);
    }
}
