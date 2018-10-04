using System;
using Newtonsoft.Json;

namespace AddressAPI3.Domain
{
    public class Address : IEntity
    {
        //Premises
        public string SubBuildingName { get; set; }
        public string BuildingName { get; set; }
        public string BuildingNumber { get; set; }
        public string Organisation { get; set; }
        public string Department { get; set; }
        public string POBox { get; set; }

        //Thoroughfare
        public string Thoroughfare { get; set; }
        public string ThoroughfareDependent { get; set; }

        //Locality
        public string Locality { get; set; }
        public string LocalityDependent { get; set; }
        public string Town { get; set; }

        //Postcode
        public string Postcode { get; set; }
        
        //public string Street { get; set; }
        //public int? Number { get; set; }
        
        public string UDPRN { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("id")]
        public Guid id { get; set; }
        public DateTime Inserted { get; set; }
    }
}
