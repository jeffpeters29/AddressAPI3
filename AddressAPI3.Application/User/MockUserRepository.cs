using System;
using AddressAPI3.MockUserData;
using System.Linq;
using System.Threading.Tasks;

namespace AddressAPI3.Application.User
{
    using Domain;

    public class MockUserRepository : IUserRepository
    {
        public User GetUser(string username, string password)
        {
            return MockUserStore.Current.Users
                                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public async Task LogActivity(ActivityLog activityLog)
        {
        }
    }
}
