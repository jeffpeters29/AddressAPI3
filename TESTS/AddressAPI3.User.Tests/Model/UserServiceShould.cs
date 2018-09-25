using AddressAPI3.Application.User;
using Xunit;

namespace AddressAPI3.User.Tests.Model
{
    // TEST - Step 1
    // Without Moq.  Instead instantiate the objects myself

    public class UserServiceShould
    {
        private const string InvalidUsername = "ZZ";
        private const string InvalidPassword = "zzz";
        private UserService _sut;

        public UserServiceShould()
        {
            var userRepository = new MockUserRepository();
            _sut = new UserService(userRepository) { _secret = "ZAGZIGZAGZIGZAGZIGZAGZIGZAGZIGZAGZIG2018" };
        }

        [Theory]
        [InlineData(InvalidUsername,InvalidPassword)]
        public void DeclineUnknownUser(string invalidUsername, string invalidPassword)
        {
            var user = _sut.Authenticate(invalidUsername, invalidPassword, "http://localhost:54741/");

            Assert.Null(user);
        }

        [Fact]
        public void AcceptKnownUser()
        {
            var user = _sut.Authenticate("AA", "aaa", "http://localhost:54741/");

            Assert.NotNull(user);
        }
    }
}
