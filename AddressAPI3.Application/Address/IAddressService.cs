using AddressAPI3.Domain;
using System.Collections.Generic;

namespace AddressAPI3.Application.Address
{
    public interface IAddressService
    {
        IEnumerable<AddressData> GetAddresses(string searchTerm);
    }
}
