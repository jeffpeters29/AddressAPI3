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

        public IEnumerable<Address> GetAddresses(string searchTerm)
        {
            var task = GetAllStartsWith(searchTerm);

            task.Wait(); //wait until task is completed

            return (IEnumerable<Address>) task.Result.Select(a => new Address()
                {
                    Postcode = a.PartitionKey,
                    Number = a.Number == string.Empty ? 0 : Convert.ToInt32(a.Number),
                    Organisation = a.Organisation,
                    Street = a.Street,
                    Town = a.Town,
                    UDPRN = a.RowKey
                })
                .Take(10)
                .ToList();
            ;
        }

        public IEnumerable<AddressGroup> GetGroupedAddresses(string searchTerm)
        {
            return null;
        }

        public IEnumerable<AddressGroup> GetFullAddresses(string postcode)
        {
            return null;
        }
    }
}
