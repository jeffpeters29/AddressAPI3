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

        public IEnumerable<Address> GetAddresses()
        {
            return _ctx.Addresses.AsNoTracking()
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

        public IEnumerable<Address> GetAddresses(string searchTerm)
        {
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
    }
}
