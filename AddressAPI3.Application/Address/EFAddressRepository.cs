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

        //public IEnumerable<Address> GetAddresses(string searchTerm)
        //{
        //    // (1) Jeff's first go at bring back the addresses (without grouping)
        //    //     Now replaced below
        //    return _ctx.Addresses.AsNoTracking()
        //        .Where(a => a.Postcode.Replace(" ", "").StartsWith(searchTerm))
        //        .OrderBy(a => a.Postcode)
        //        .Take(10)
        //        .Select(a => new Address()
        //        {
        //            Postcode = a.Postcode,
        //            Number = a.Number,
        //            Organisation = a.Organisation,
        //            Street = a.Street,
        //            Town = a.Town,
        //            UDPRN = a.UDPRN
        //        })
        //        .ToList();
        //}

        public IEnumerable<AddressData> GetGroupedAddresses(string searchTerm)
        {
            // (2) Now replaced with 2 step process 
            //     Step 1 - Groups with counts
            return _ctx.Addresses.AsNoTracking()
                                 .Where(a => a.Postcode.Replace(" ", "").StartsWith(searchTerm))
                                 .GroupBy(a => new { a.Postcode, a.Town, a.Thoroughfare })     
                                 .Select(a => new AddressData()
                                 {
                                     Thoroughfare = a.Key.Thoroughfare,
                                     Town = a.Key.Town,
                                     Postcode = a.Key.Postcode,
                                     IsPostcode = false,
                                     Count = a.Count()
                                 })
                                 .Take(10)
                                 .OrderBy(a => a.Postcode)
                                 .ToList();
        }

        public IEnumerable<AddressData> GetFullAddresses(string postcode)
        {
            var x = _ctx.Addresses.AsNoTracking()
                .Where(a => a.Postcode == postcode)
                .OrderByDescending(a => a.Organisation ?? string.Empty)
                .ThenBy(a => a.BuildingNumber ?? string.Empty)
                .ToList();

            // (2) Step 2 - Details of specific postcode chosen by user
            return _ctx.Addresses.AsNoTracking()
                .Where(a => a.Postcode == postcode)
                .Select(a => new AddressData()
                {
                    SubBuildingName = a.SubBuildingName,
                    BuildingName = a.BuildingName,
                    BuildingNumber = a.BuildingNumber,
                    Organisation = a.Organisation,
                    Department = a.Department,
                    POBox = a.POBox,
                    Thoroughfare = a.Thoroughfare,
                    ThoroughfareDependent = a.ThoroughfareDependent,
                    Locality = a.Locality,
                    LocalityDependent = a.LocalityDependent,
                    Town = a.Town,
                    Postcode = a.Postcode,
                    IsPostcode = true
                })
                .OrderByDescending(a => a.Organisation ?? string.Empty)
                .ThenBy(a => a.BuildingNumber ?? string.Empty)
                .ToList();
        }

    }
}
