using System;
using Newtonsoft.Json;

namespace AddressAPI3.Domain
{
    public class Address : IEntity
    {
        public string Postcode { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string Organisation { get; set; }
        public string UDPRN { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("id")]
        public Guid id { get; set; }
        public DateTime Inserted { get; set; }
    }
}
