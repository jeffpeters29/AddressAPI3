using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressAPI3.Application.Address
{
    //TODO - Remember indexing policy may improve perf - (hash vs range)
    //Hash = equality; range is greater / less than  >= PL

    using Domain;
    using Microsoft.Azure.Documents;

    public class CosmosRepository : IAddressRepository
    {
        private readonly DocumentClient _client;
        private readonly Uri _collectionUri;

        public CosmosRepository(string uri, string key, string database, string collection)
        {
            _client = new DocumentClient(new Uri(uri), key);
            _collectionUri = UriFactory.CreateDocumentCollectionUri(database, collection);
        }

        public IEnumerable<Address> GetAddresses(string searchTerm)
        {
            var addresses = _client.CreateDocumentQuery<Address>(_collectionUri)
                                   .OrderBy(a => a.Number)
                                   .ToList();
            return addresses;
        }

        public IEnumerable<AddressData> GetGroupedAddresses(string searchTerm)
        {
            var sql = $"SELECT * FROM Addresses a WHERE STARTSWITH(a.postcode,'{searchTerm}') = true";
            var options = new FeedOptions { EnableCrossPartitionQuery = true };

            try
            {
                var addresses = _client.CreateDocumentQuery<Address>(_collectionUri, sql, options)
                                       .AsEnumerable()
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

                return addresses;
            }
            catch (DocumentClientException ex)
            {
                var strEx = ex.Message;

                if (ex.StatusCode.HasValue && (int)ex.StatusCode.Value == 429)
                {
                    // TODO - Request was throttled.  Email me to up the RU's!!
                }

                throw;
            }
            catch (Exception ex)
            {
                var strEx = ex.Message;
                throw;
            }
        }

        public IEnumerable<AddressData> GetFullAddresses(string postcode)
        {
            var sql = $"SELECT * FROM Addresses a WHERE a.postcode ='{postcode}'";
            var options = new FeedOptions { PartitionKey = new PartitionKey(postcode) };

            try
            {
                var addresses = _client.CreateDocumentQuery<Address>(_collectionUri, sql, options)
                                       .AsEnumerable()
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

                return addresses;
            }
            catch (Exception ex)
            {
                var strEx = ex.Message;
                throw;
            }
        }
    }
}
