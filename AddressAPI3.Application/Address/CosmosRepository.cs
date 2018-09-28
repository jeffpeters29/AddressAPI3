using AddressAPI3.Domain;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.Documents.SystemFunctions;

namespace AddressAPI3.Application.Address
{
    //TODO - Remember indexing policy may improve perf - (hash vs range)
    //Hash = equality; range is greater / less than  >= PL

    public class CosmosRepository : IAddressRepository
    {
        private readonly DocumentClient _client;
        private readonly Uri _collectionLink;

        public CosmosRepository(string uri, string key, string database, string collection)
        {
            _client = new DocumentClient(new Uri(uri), key);
            _collectionLink = UriFactory.CreateDocumentCollectionUri(database, collection);
        }

        public IEnumerable<Domain.Address> GetAddresses(string searchTerm)
        {
            var addresses = _client.CreateDocumentQuery<Domain.Address>(_collectionLink)
                                   .OrderBy(a => a.Number)
                                   .ToList();
            return addresses;
        }

        public IEnumerable<AddressData> GetGroupedAddresses(string searchTerm)
        {
            try
            {
                var addresses = _client.CreateDocumentQuery<Domain.Address>(_collectionLink)
                    .Where(a => a.Postcode.Replace(" ", "").StartsWith(searchTerm))
                    .AsEnumerable()
                    .GroupBy(a => new {a.Postcode, a.Town, a.Street})
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
                if (ex.StatusCode.HasValue && (int) ex.StatusCode.Value == 429)
                {
                    // TODO - Request was throttled.  Email me to up the RU's!!
                }

                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<AddressData> GetFullAddresses(string postcode)
        {
            var addresses = _client.CreateDocumentQuery<Domain.Address>(_collectionLink)
                                    .Where(a => a.Postcode == postcode)
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

        //public IEnumerable<AddressData> GetFullAddressesSql(string postcode)
        //{
        //    var sql = $"SELECT * FROM Addresses a WHERE STARTSWITH(a.postcode,\"{postcode}\") = true";

        //    var addresses = _client.CreateDocumentQuery<Domain.Address>(_collectionLink,sql)
        //                            .AsEnumerable()
        //                            .Select(a => new AddressData()
        //                            {
        //                                Postcode = a.Postcode,
        //                                Organisation = a.Organisation,
        //                                Number = a.Number,
        //                                Town = a.Town,
        //                                Street = a.Street,
        //                                IsPostcode = true
        //                            })
        //                            .OrderByDescending(a => a.Organisation ?? string.Empty)
        //                            .ThenBy(a => a.Number != null ? a.Number.ToString() : string.Empty)
        //                            .ToList();

        //    return addresses;
        //}
    }
}
