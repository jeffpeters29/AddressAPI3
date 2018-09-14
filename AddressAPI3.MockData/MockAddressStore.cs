using System.Collections.Generic;
using AddressAPI3.Domain;

namespace AddressAPI3.MockData
{
    public class MockAddressStore
    {
        public static MockAddressStore Current { get; } = new MockAddressStore();

        public List<Address> Addresses { get; set; }

        public MockAddressStore()
        {
            Addresses = new List<Address>()
            {
                new Address()
                {
                    Id = 1,
                    UDPRN = "11111111",
                    Postcode = "N1 1QQ",
                    Town = "Winchester",
                    Street = "High Street",
                    Number = 1,
                    Organisation = "Post Office"
                },
                new Address()
                {
                    Id = 2,
                    UDPRN = "22222222",
                    Postcode = "N2 1QQ",
                    Town = "Watford",
                    Street = "High Street",
                    Number = 2,
                    Organisation = "W H Smith"
                },
                new Address()
                {
                    Id = 3,
                    UDPRN = "33333333",
                    Postcode = "N3 1QQ",
                    Town = "Walsall",
                    Street = "High Street",
                    Number = 3,
                    Organisation = "JD Sports"
                },
                new Address()
                {
                    Id = 4,
                    UDPRN = "44444444",
                    Postcode = "N4 1QQ",
                    Town = "Welling",
                    Street = "High Street",
                    Number = 4,
                    Organisation = null
                },
                new Address()
                {
                    Id = 5,
                    UDPRN = "55555555",
                    Postcode = "N5 1QQ",
                    Town = "Wales",
                    Street = "High Street",
                    Number = null,
                    Organisation = "Woolworths"
                }
            };
        }
    }
}
