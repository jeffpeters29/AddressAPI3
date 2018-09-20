using AddressAPI3.Domain;
using System.Collections.Generic;

namespace AddressAPI3.Application.Address
{
    public interface IAddressService
    {
        IEnumerable<AddressGroup> GetAddresses(string searchTerm);
    }
}
