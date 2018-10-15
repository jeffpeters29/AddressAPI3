using AddressAPI3.Domain;
using Newtonsoft.Json;

namespace AddressAPI3.Application.Helpers
{
    public static class AddressExtensions
    {
        public static bool IsCompletePostcode(this string inputString)
        {
            inputString = inputString.RemoveWhiteSpace();

            var IsStartsTwoChars = inputString.IsStartsTwoChars();

            return inputString.Length > (IsStartsTwoChars ? 6 : 5); 
        }

        public static string ToFormattedString(this AddressData addressData)
        {
            // Postcode
            var postcode = !string.IsNullOrEmpty(addressData.PostcodeDisplay) ? addressData.PostcodeDisplay.Trim() : addressData.Postcode.Trim();

            // StartText : for specific postcodes
            var organisation = !string.IsNullOrEmpty(addressData.Organisation) ? addressData.Organisation.Trim() + ", " : string.Empty;
            var department = !string.IsNullOrEmpty(addressData.Department) ? addressData.Department.Trim() + ", " : string.Empty;
            var buildingNumber = !string.IsNullOrEmpty(addressData.BuildingNumber) ? addressData.BuildingNumber.Trim() + " " : string.Empty; 
            var buildingName = !string.IsNullOrEmpty(addressData.BuildingName) ? addressData.BuildingName.Trim() + " " : string.Empty; 
            var subBuildingName = !string.IsNullOrEmpty(addressData.SubBuildingName) ? addressData.SubBuildingName.Trim() + " " : string.Empty;
            var premises = subBuildingName + buildingName + buildingNumber;
            var startText = (organisation + department + premises).Trim();
            startText += startText.Length > 0 ? " " : string.Empty;
            // Thoroughfare 
            var thoroughfare = !string.IsNullOrEmpty(addressData.Thoroughfare) ? addressData.Thoroughfare.Trim() + ", " : string.Empty;

            // Count : for grouped postcodes
            var countText = (addressData.Count > 0)
                            ? " - " + $"{addressData.Count} " + ((addressData.Count == 1) ? "address" : "addresses")
                            : string.Empty;

            return $"{postcode} : {startText}{thoroughfare} {addressData.Town}" + countText
                 + $"<span style='display:none'>{JsonConvert.SerializeObject(addressData)}</span>";
        }
    }
}
