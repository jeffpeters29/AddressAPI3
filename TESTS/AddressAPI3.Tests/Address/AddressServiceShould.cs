using System;
using AddressAPI3.Application.Address;
using AddressAPI3.Application.User;
using AddressAPI3.Domain;
using Moq;
using Xunit;

namespace AddressAPI3.Tests
{
    // TEST - Step 2
    // Using Moq.  Instead instantiate the objects myself

    public class AddressServiceShould
    {
        [Fact]
        public void Test1()
        {
            var mockUserService = new Mock<IUserService>();

            mockUserService.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new User()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Ant",
                    Password = "aaa",
                    Username = "AA"
                });

            Assert.Equal(1,1);
        }
    }
}
