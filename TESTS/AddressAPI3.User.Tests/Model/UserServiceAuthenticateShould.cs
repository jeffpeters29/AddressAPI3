using AddressAPI3.Application.User;
using Xunit;

namespace AddressAPI3.User.Tests.Model
{
    public class UserServiceAuthenticateShould
    {
        [Fact]
        public void DeclineUnknownUser()
        {
            var userRepository = new MockUserRepository();
            var sut = new UserService(userRepository) { _secret = "ZAGZIGZAGZIGZAGZIGZAGZIGZAGZIGZAGZIG2018" };

            var user = sut.Authenticate("ZZ", "zzz", "http://localhost:54741/");

            Assert.Null(user);
        }

        [Fact]
        public void AcceptKnownUser()
        {
            var userRepository = new MockUserRepository();
            var sut = new UserService(userRepository) { _secret = "ZAGZIGZAGZIGZAGZIGZAGZIGZAGZIGZAGZIG2018" };

            var user = sut.Authenticate("AA", "aaa", "http://localhost:54741/");

            Assert.NotNull(user);
        }
    }
}
