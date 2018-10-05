using Newtonsoft.Json;

namespace AddressAPI3.Domain
{
    public class AddressData : Address
    {
        public string FormattedText { get; set; }
        public int Count { get; set; }
        public bool IsPostcode { get; set; }
    }
}
