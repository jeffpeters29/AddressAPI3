using AddressAPI3.Application.Helpers;
using AddressAPI3.Domain;
using System.Collections.Generic;

namespace AddressAPI3.Application.Address
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IEnumerable<AddressGroup> GetAddresses(string searchTerm)
        {
            var addresses = searchTerm.IsPostcodeLength()
                ? _addressRepository.GetFullAddresses(searchTerm)
                : _addressRepository.GetGroupedAddresses(searchTerm);

            foreach (var address in addresses)
            {
                address.FormattedText = address.ToFormattedString();
            }

            return addresses;
        }
    }
}
