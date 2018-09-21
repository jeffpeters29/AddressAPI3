using System.Collections.Generic;

namespace AddressAPI3.Application.Address
{
    using Domain;

    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses(string searchTerm);

        IEnumerable<AddressData> GetGroupedAddresses(string searchTerm);

        IEnumerable<AddressData> GetFullAddresses(string postcode);
    }
}
