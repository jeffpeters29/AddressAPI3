using System;
using System.Linq;
using AddressAPI3.Common.Security;
using AddressAPI3.EFUserData;

namespace AddressAPI3.Application.User
{
    using Domain;

    public class EFUserRepository : IUserRepository
    {
        private readonly UserContext _ctx;
        private readonly IPasswordHashService _passwordHashService;

        public EFUserRepository(UserContext ctx, IPasswordHashService passwordHashService)
        {
            _ctx = ctx;
            _passwordHashService = passwordHashService;
        }

        public User GetUser(string username, string password)
        {
            var hashedPassword = _passwordHashService.HashPassword(password);

            if (string.IsNullOrEmpty(hashedPassword)) throw new ArgumentException("Password hash not valid");

            return _ctx.Users.Where(u => u.Username == username && u.PasswordHash == hashedPassword)
                             .Select(u => new User()
                                    {
                                        Username = u.Username,
                                        FirstName = u.FirstName,
                                        LastName = u.LastName
                                    })
                             .FirstOrDefault();  
        }
    }
}
