using Microsoft.WindowsAzure.Storage.Table;

namespace AddressAPI3.AzureData.Entities
{
    public class Address : TableEntity
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Organisation { get; set; }
        public int Id { get; set; }
    }
}
