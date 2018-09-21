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
            // (1) Jeff's first go at bring back the addresses (without grouping)
            //     Now replaced below
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

        public IEnumerable<AddressData> GetGroupedAddresses(string searchTerm)
        {
            return _ctx.Addresses.AsNoTracking()
                                 .Where(a => a.Postcode.Replace(" ", "").StartsWith(searchTerm))
                                 .GroupBy(a => new { a.Postcode, a.Town, a.Street })
                                 .Select(a => new AddressData()
                                 {
                                     Postcode = a.Key.Postcode,
                                     Town = a.Key.Town,
                                     Street = a.Key.Street,
                                     Count = a.Count(),
                                     IsPostcode = false
                                 })
                                 .Take(10)
                                 .OrderBy(a => a.Postcode)
                                 .ToList();
        }

        public IEnumerable<AddressData> GetFullAddresses(string postcode)
        {
            return _ctx.Addresses.AsNoTracking()
                .Where(a => a.Postcode == postcode)
                .Select(a => new AddressData()
                {
                    Postcode = a.Postcode,
                    Organisation = a.Organisation,
                    Number = a.Number,
                    Town = a.Town,
                    Street = a.Street,
                    IsPostcode = true
                })
                .OrderByDescending(a => a.Organisation ?? string.Empty)
                .ThenBy(a => a.Number != null ? a.Number.ToString() : string.Empty)
                .ToList();
        }

    }
}
