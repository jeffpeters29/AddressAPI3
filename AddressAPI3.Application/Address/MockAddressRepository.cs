using AddressAPI3.MockData;
using System.Collections.Generic;
using System.Linq;

namespace AddressAPI3.Application.Address
{
    using Domain;

    public class MockAddressRepository : IAddressRepository
    {

        public IEnumerable<Address> GetAddresses(string searchTerm)
        {
            return MockAddressStore.Current.Addresses
                .Where(a => a.Postcode.StartsWith(searchTerm))
                .OrderBy(a => a.Postcode)
                .ToList();
        }

        public IEnumerable<AddressGroup> GetGroupedAddresses(string searchTerm)
        {
            return null;
        }

        public IEnumerable<AddressGroup> GetFullAddresses(string postcode)
        {
            return null;
        }
    }
}
