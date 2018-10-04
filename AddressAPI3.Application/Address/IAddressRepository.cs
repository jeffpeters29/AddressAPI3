using System.Collections.Generic;

namespace AddressAPI3.Application.Address
{
    using Domain;

    public interface IAddressRepository
    {
        IEnumerable<AddressData> GetGroupedAddresses(string searchTerm);

        IEnumerable<AddressData> GetFullAddresses(string postcode);
    }
}
