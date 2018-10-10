using System.Collections.Generic;
using AddressAPI3.Domain;

namespace AddressAPI3.MockData
{
    public class MockAddressStore
    {
        public static MockAddressStore Current { get; } = new MockAddressStore();

        public List<Address> Addresses { get; set; }

        public MockAddressStore()
        {
            Addresses = new List<Address>()
            {
                new Address()
                {
                    Id = 1,
                    //UDPRN = "11111111",
                    SubBuildingName = null,
                    BuildingName = "Unit B",
                    BuildingNumber = null,
                    Organisation = "Laura Ashley Ltd",
                    Department = null,
                    POBox = null,
                    Thoroughfare = "Armada Way",
                    ThoroughfareDependent = "The Armada Centre",
                    Locality = null,
                    LocalityDependent = null,
                    Town = "Winchester",
                    Postcode = "N1 1QQ"
                },
                new Address()
                {
                    Id = 2,
                    //UDPRN = "22222222",
                    SubBuildingName = "Unit 12a-13",
                    BuildingName = null,
                    BuildingNumber = "8",
                    Organisation = "Beaumont Drylining Ltd",
                    Department = null,
                    POBox = null,
                    Thoroughfare = "Bell Close",
                    ThoroughfareDependent = "The Armada Centre",
                    Locality = "Plympton",
                    LocalityDependent = "Newnham Industrial Estate",
                    Town = "Watford",
                    Postcode = "N2 1QQ"
                },
                new Address()
                {
                    Id = 3,
                   //UDPRN = "33333333",
                    SubBuildingName = "Unit 16",
                    BuildingName = null,
                    BuildingNumber = null,
                    Organisation = "Build A Bear",
                    Department = null,
                    POBox = null,
                    Thoroughfare = "Charles Street",
                    ThoroughfareDependent = null,
                    Locality = null,
                    LocalityDependent = null,
                    Town = "Walsall",
                    Postcode = "N3 1QQ"
                },
                new Address()
                {
                    Id = 4,
                    //UDPRN = "44444444",
                    SubBuildingName = null,
                    BuildingName = null,
                    BuildingNumber = null,
                    Organisation = "Ministry Of Defence",
                    Department = "Royal Marines",
                    POBox = null,
                    Thoroughfare = "Durnford Street",
                    ThoroughfareDependent = "Stonehouse Barracks",
                    Locality = null,
                    LocalityDependent = null,
                    Town = "Wrexham",
                    Postcode = "N4 1QQ"
                },
                new Address()
                {
                    Id = 5,
                    //UDPRN = "55555555",
                    SubBuildingName = null,
                    BuildingName = null,
                    BuildingNumber = null,
                    Organisation = "Lloyds Bank Regional Securities",
                    Department = null,
                    POBox = "300",
                    Thoroughfare = null,
                    ThoroughfareDependent = null,
                    Locality = null,
                    LocalityDependent = null,
                    Town = "Wolverhampton",
                    Postcode = "N5 1QQ"
                },
                new Address()
                {
                    Id = 6,
                    //UDPRN = "66666666",
                    SubBuildingName = "Flat 31",
                    BuildingName = null,
                    BuildingNumber = "8",
                    Organisation = null,
                    Department = null,
                    POBox = null,
                    Thoroughfare = "St. Andrews Cross",
                    ThoroughfareDependent = null,
                    Locality = null,
                    LocalityDependent = null,
                    Town = "Worthing",
                    Postcode = "N6 1QQ"
                },
                new Address()
                {
                    Id = 7,
                    //UDPRN = "77777777",
                    SubBuildingName = null,
                    BuildingName = "93-94",
                    BuildingNumber = null,
                    Organisation = "Ians Mobiles Ltd",
                    Department = null,
                    POBox = null,
                    Thoroughfare = "The Market",
                    ThoroughfareDependent = null,
                    Locality = null,
                    LocalityDependent = null,
                    Town = "Wroxham",
                    Postcode = "N6 1QQ"
                },
                new Address()
                {
                    Id = 7,
                    //UDPRN = "77777777",
                    SubBuildingName = null,
                    BuildingName = "93-94",
                    BuildingNumber = null,
                    Organisation = "Ians Mobiles Ltd",
                    Department = null,
                    POBox = null,
                    Thoroughfare = "The Market",
                    ThoroughfareDependent = null,
                    Locality = null,
                    LocalityDependent = null,
                    Town = "Wroxham",
                    Postcode = "N7 1QQ"
                },
                new Address()
                {
                    Id = 8,
                    //UDPRN = "88888888",
                    SubBuildingName = null,
                    BuildingName = "Crow Park House",
                    BuildingNumber = null,
                    Organisation = null,
                    Department = null,
                    POBox = null,
                    Thoroughfare = "Fernleigh Road",
                    ThoroughfareDependent = "Crow Park",
                    Locality = null,
                    LocalityDependent = null,
                    Town = "Walthamstow",
                    Postcode = "N8 1QQ"
                },
                new Address()
                {
                    Id = 9,
                    //UDPRN = "99999999",
                    SubBuildingName = null,
                    BuildingName = "Unit 21",
                    BuildingNumber = null,
                    Organisation = "County Chiropractic Plymouth Ltd",
                    Department = null,
                    POBox = null,
                    Thoroughfare = "Beacon Park Road",
                    ThoroughfareDependent = "Scott Business Park",
                    Locality = null,
                    LocalityDependent = null,
                    Town = "Windsor",
                    Postcode = "N9 1QQ"
                }
            };
        }
    }
}
