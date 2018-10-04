using System;
using System.Collections.Generic;
using System.Linq;
using AddressAPI3.AzureData;

namespace AddressAPI3.Application.Address
{
    using Domain;

    public class AzureAddressRepository : TableAccessProvider<AzureData.Entities.Address>, IAddressRepository
    {
        public AzureAddressRepository(string cnnString) : base(cnnString)
        {
        }

        //public IEnumerable<Address> GetAddresses(string searchTerm)
        //{
        //    var task = GetAllStartsWith(searchTerm);

        //    task.Wait(); 

        //    return task.Result.Select(a => new Address()
        //        {
        //            Postcode = a.PartitionKey,
        //            Number = a.Number == string.Empty ? 0 : Convert.ToInt32(a.Number),
        //            Organisation = a.Organisation,
        //            Street = a.Street,
        //            Town = a.Town,
        //            UDPRN = a.RowKey
        //        })
        //        .Take(10)
        //        .ToList();
        //    ;
        //}

        public IEnumerable<Address> GetAddresses(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddressData> GetGroupedAddresses(string searchTerm)
        {
            return null;
        }

        public IEnumerable<AddressData> GetFullAddresses(string postcode)
        {
            return null;
        }
    }
}
