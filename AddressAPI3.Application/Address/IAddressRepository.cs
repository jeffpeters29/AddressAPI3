using System.Collections.Generic;

namespace AddressAPI3.Application.Address
{
    using Domain;

    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses(string searchTerm);

        IEnumerable<AddressGroup> GetGroupedAddresses(string searchTerm);

        IEnumerable<AddressGroup> GetFullAddresses(string postcode);
    }
}
