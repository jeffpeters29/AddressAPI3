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

        public IEnumerable<AddressData> GetGroupedAddresses(string searchTerm)
        {
            // Step 1 : Groups with counts
            return _ctx.Postcodes.AsNoTracking()
                                 .Where(p => p.Id.Replace(" ", "").StartsWith(searchTerm))
                                 .GroupBy(p => new { p.Id, p.Town, p.Description })     
                                 .Select(p => new AddressData()
                                 {
                                     Thoroughfare = p.Key.Description,
                                     Town = p.Key.Town,
                                     Postcode = p.Key.Id,
                                     IsPostcode = false,
                                     Count = p.Count()
                                 })
                                 .Take(10)
                                 .OrderBy(p => p.Postcode)
                                 .ToList();
        }

        public IEnumerable<AddressData> GetFullAddresses(string postcode)
        {
            // Step 2 : Get details of the specific postcode chosen by user
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
