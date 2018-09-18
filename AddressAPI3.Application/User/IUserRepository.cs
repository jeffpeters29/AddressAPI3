using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressAPI3.Application.User
{
    using Domain;

    public interface IUserRepository
    {
        User GetUser(string username, string password);

        Task LogActivity(ActivityLog activityLog);
    }
}
