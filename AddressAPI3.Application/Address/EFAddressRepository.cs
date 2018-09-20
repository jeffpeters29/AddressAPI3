using AddressAPI3.EFData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AddressAPI3.Application.Address
{
    using Domain;

    public class EFAddressRepository : IAddressRepository
    {
        private readonly AddressContext _ctx;

        public EFAddressRepository(AddressContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Address> GetAddresses(string searchTerm)
        {
            // (1) First go at bring back the addresses (without grouping)
            return _ctx.Addresses.AsNoTracking()
                .Where(a => a.Postcode.Replace(" ", "").StartsWith(searchTerm))
                .OrderBy(a => a.Postcode)
                .Take(10)
                .Select(a => new Address()
                {
                    Postcode = a.Postcode,
                    Number = a.Number,
                    Organisation = a.Organisation,
                    Street = a.Street,
                    Town = a.Town,
                    UDPRN = a.UDPRN
                })
                .ToList();
        }

        public IEnumerable<AddressGroup> GetGroupedAddresses(string searchTerm)
        {
            return _ctx.Addresses.AsNoTracking()
                                 .Where(a => a.Postcode.Replace(" ", "").StartsWith(searchTerm))
                                 .GroupBy(a => new { a.Postcode, a.Town, a.Street })
                                 .Select(address => new AddressGroup()
                                 {
                                    Postcode = address.Key.Postcode,
                                    Town = address.Key.Town,
                                    Street = address.Key.Street,
                                    Count = address.Count()
                                 })
                                 .Take(10)
                                 .OrderBy(a => a.Postcode)
                                 .ToList();
        }

        public IEnumerable<AddressGroup> GetFullAddresses(string postcode)
        {
            throw new System.NotImplementedException();
        }
        
    }
}
