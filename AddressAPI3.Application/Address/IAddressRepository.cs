using System.Collections.Generic;

namespace AddressAPI3.Application.Address
{
    using Domain;

    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();

        IEnumerable<Address> GetAddresses(string searchTerm);
    }
}
